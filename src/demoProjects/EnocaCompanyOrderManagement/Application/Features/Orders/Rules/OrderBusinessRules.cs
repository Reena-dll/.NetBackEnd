using Application.Features.Orders.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Rules
{
    public class OrderBusinessRules
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public OrderBusinessRules(IOrderRepository orderRepository, IProductRepository productRepository, ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public void ProductShouldExistWhenRequested(Order order)
        {
            if (order == null) throw new BusinessException(OperationClaims.RequestedOrder);
        }

        public async Task ProductShouldExistWhenOrderCreated(int id)
        {
            Product? result = await _productRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(OperationClaims.ProductShouldExistWhenOrderCreated);
        }

        public async Task CompanyShouldExistWhenOrderCreated(int id)
        {
            Company? result = await _companyRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(OperationClaims.CompanyShouldExistWhenOrderCreated);
        }

        public async Task UserShouldExistWhenOrderCreated(int id)
        {
            User? result = await _userRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(OperationClaims.UserShouldExistWhenOrderCreated);
        }

        public async Task UnapprovedCompanyError(int id)
        { 
            Company? result = await _companyRepository.GetAsync(b => b.Id == id);
            if (result.Status == false) throw new BusinessException(OperationClaims.UnapprovedCompanyError);
        }

        public async Task ThisProductDoesNotBelongToThatCompany(int companyId, int productId)
        {
            Product? result = await _productRepository.GetAsync(b => b.Id == productId && b.CompanyId == companyId );
            if (result == null) throw new BusinessException(OperationClaims.ThisProductDoesNotBelongToThatCompany);
        }

        public async Task DateControl(int id, DateTime date)
        {
            Company? result = await _companyRepository.GetAsync(b => b.Id == id);

            TimeSpan CurrentTime = DateTime.Now.TimeOfDay;


            if (result.OrderStartDate > date.TimeOfDay || date.TimeOfDay > result.OrderFinishDate )
            {
                throw new BusinessException(OperationClaims.DateControl);
            }
        }

    }
}
