using Application.Features.Companies.Dtos;
using Application.Features.Companies.Rules;
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

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdatedProductDto>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                await _productBusinessRules.CompanyShouldExistWhenUpdated(request.CompanyId);
                await _productBusinessRules.ProductShouldExistWhenUpdated(request.Id);


                Product mappedProduct = _mapper.Map<Product>(request);
                Product updatedProduct = await _productRepository.UpdateAsync(mappedProduct);
                UpdatedProductDto updatedProductDto = _mapper.Map<UpdatedProductDto>(updatedProduct);


                return updatedProductDto;
            }
        }
    }
}
