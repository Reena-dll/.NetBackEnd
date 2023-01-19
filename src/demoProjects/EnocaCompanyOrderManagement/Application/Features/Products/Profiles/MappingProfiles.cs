using Application.Features.Companies.Dtos;
using Application.Features.Companies.Models;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreatedProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();

            CreateMap<Product, UpdatedProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

            CreateMap<Product, DeletedProductDto>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();

            CreateMap<Product, ProductListDto>()
                .ForMember(c=> c.CompanyName, opt=> opt.MapFrom(c=> c.Company.Name))
                .ReverseMap();
            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();

            CreateMap<Product, ProductGetByIdDto>()
                .ForMember(c => c.CompanyName, opt => opt.MapFrom(c => c.Company.Name))
                .ReverseMap();

        }
    }
}
