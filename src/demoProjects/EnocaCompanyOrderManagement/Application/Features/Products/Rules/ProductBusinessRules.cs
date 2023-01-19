using Application.Features.Products.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;
        private readonly ICompanyRepository _companyRepository;

        public ProductBusinessRules(IProductRepository productRepository, ICompanyRepository companyRepository)
        {
            _productRepository = productRepository;
            _companyRepository = companyRepository;
        }

        public async Task ProductNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Product> result = await _productRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(OperationClaims.ProductNameExists);
        }

        public void ProductShouldExistWhenRequested(Product product)
        {
            if (product == null) throw new BusinessException(OperationClaims.RequestedProduct);
        }

        public async Task ProductShouldExistWhenUpdated(int id)
        {
            Product? result = await _productRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(OperationClaims.RequestedProduct);
        }

        public async Task CompanyShouldExistWhenUpdated(int id)
        {
            Company? result = await _companyRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(OperationClaims.RequestedCompany);
        }


    }
}

