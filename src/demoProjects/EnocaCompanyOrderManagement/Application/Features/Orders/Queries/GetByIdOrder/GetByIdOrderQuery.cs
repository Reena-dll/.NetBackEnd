using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
using Application.Features.Orders.Rules;
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

namespace Application.Features.Orders.Queries.GetByIdOrder
{
    public class GetByIdOrderQuery : IRequest<OrderGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, OrderGetByIdDto>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            private readonly OrderBusinessRules _orderBusinessRules;

            public GetByIdOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper, OrderBusinessRules orderBusinessRules)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
                _orderBusinessRules = orderBusinessRules;
            }

            public async Task<OrderGetByIdDto> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
            {

                Order? order = await _orderRepository.Query()
                    .Include(t => t.User)
                    .Include(t => t.Product)
                    .Include(t => t.Product.Company)
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);


                 _orderBusinessRules.ProductShouldExistWhenRequested(order);

                OrderGetByIdDto mappedOrderModel = _mapper.Map<OrderGetByIdDto>(order);

                return mappedOrderModel;
            }
        }
    }
}
