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

namespace Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeletedProductDto>
    {
        public int Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;

            public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<DeletedProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                await _productBusinessRules.ProductShouldExistWhenUpdated(request.Id);

                var deleteProductData = _productRepository.Get(x => x.Id == request.Id);
                deleteProductData.IsDeleted = true;

                Product mappedProduct = _mapper.Map<Product>(deleteProductData);
                Product deletedProduct = await _productRepository.UpdateAsync(mappedProduct);
                DeletedProductDto deletedProductDto = _mapper.Map<DeletedProductDto>(deletedProduct);

                return deletedProductDto;
            }
        }
    }
}
