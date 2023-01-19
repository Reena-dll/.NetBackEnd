using Application.Features.Companies.Dtos;
using Application.Features.Companies.Models;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
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

namespace Application.Features.Orders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {


            CreateMap<Order, OrderListDto>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(c => c.ProductName, opt => opt.MapFrom(c => c.Product.Name))
                .ForMember(c => c.CompanyName, opt => opt.MapFrom(x => x.Company.Name))
                .ReverseMap();

            CreateMap<Order, OrderGetByIdDto>()
               .ForMember(c => c.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(c => c.ProductName, opt => opt.MapFrom(c => c.Product.Name))
                .ForMember(c => c.CompanyName, opt => opt.MapFrom(x => x.Company.Name))
                .ReverseMap();

            CreateMap<IPaginate<Order>, OrderListModel>().ReverseMap();

            CreateMap<IPaginate<Order>, OrderGetByIdDto>().ReverseMap();

            CreateMap<Order, CreatedOrderDtos>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();


        }
    }
}
