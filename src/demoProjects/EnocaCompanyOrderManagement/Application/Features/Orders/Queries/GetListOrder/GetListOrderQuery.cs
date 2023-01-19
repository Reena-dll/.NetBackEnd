﻿using Application.Features.Orders.Models;
using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetListOrder
{
    public class GetListOrderQuery : IRequest<OrderListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, OrderListModel>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public GetListOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<OrderListModel> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Order> orders = await _orderRepository.GetListAsync(x => x.IsDeleted == false,
                    include:
                    p=> p.Include(c => c.User).Include(x=> x.Product).Include(x=> x.Product.Company),

                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                OrderListModel mappedOrderModel = _mapper.Map<OrderListModel>(orders);

                return mappedOrderModel;
            }
        }
    }
}
