using Application.Features.Orders.Dtos;
using Application.Features.Orders.Rules;
using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand: IRequest<CreatedOrderDtos>
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } 

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderDtos>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            private readonly OrderBusinessRules _orderBusinessRules;

            public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, OrderBusinessRules orderBusinessRules)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
                _orderBusinessRules = orderBusinessRules;
            }

            public async Task<CreatedOrderDtos> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                await _orderBusinessRules.ProductShouldExistWhenOrderCreated(request.ProductId);
                await _orderBusinessRules.CompanyShouldExistWhenOrderCreated(request.CompanyId);
                await _orderBusinessRules.UnapprovedCompanyError(request.CompanyId);
                await _orderBusinessRules.UserShouldExistWhenOrderCreated(request.UserId);
                await _orderBusinessRules.ThisProductDoesNotBelongToThatCompany(request.CompanyId,request.ProductId);
                await _orderBusinessRules.DateControl(request.CompanyId,request.OrderDate);

                Order mappedOrder = _mapper.Map<Order>(request);
                Order createdOrder = await _orderRepository.AddAsync(mappedOrder);
                CreatedOrderDtos createdOrderDtos = _mapper.Map<CreatedOrderDtos>(createdOrder);

                return createdOrderDtos;
            }
        }
    }
}
