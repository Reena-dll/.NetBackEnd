using Application.Features.Orders.Models;
using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetListOrderByDynamic
{
    public class GetListOrderByDynamicQuery : IRequest<OrderListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListOrderByDynamicQueryHandler : IRequestHandler<GetListOrderByDynamicQuery, OrderListModel>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public GetListOrderByDynamicQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<OrderListModel> Handle(GetListOrderByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Order> orders = await _orderRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include:
                    p => p.Include(c => c.Company),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                OrderListModel mappedOrderListModel = _mapper.Map<OrderListModel>(orders);

                return mappedOrderListModel;
            }
        }
    }
}
