﻿using Application.Features.Products.Models;
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

namespace Application.Features.Products.Queries.GetListProductByDynamic
{
    public class GetListProductByDynamicQuery : IRequest<ProductListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListProductByDynamicQueryHandler : IRequestHandler<GetListProductByDynamicQuery, ProductListModel>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetListProductByDynamicQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ProductListModel> Handle(GetListProductByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Product> products = await _productRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include:
                    p => p.Include(c => c.Company),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                ProductListModel mappedProductListModel = _mapper.Map<ProductListModel>(products);

                return mappedProductListModel;
            }
        }
    }
}
