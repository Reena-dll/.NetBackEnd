using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Commands.DeleteCompany;
using Application.Features.Companies.Commands.UpdateCompany;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Models;
using Application.Features.Products.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CreatedCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();

            CreateMap<IPaginate<Company>, CompanyListModel>().ReverseMap();
            CreateMap<Company, CompanyListDto>().ReverseMap();

            CreateMap<Company, CompanyGetByIdDto>().ReverseMap();

            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, UpdatedCompanyDto>().ReverseMap();

            CreateMap<Company, DeleteCompanyCommand>().ReverseMap();
            CreateMap<Company, DeletedCompanyDto>().ReverseMap();

            CreateMap<IPaginate<Company>, CompanyListModel>().ReverseMap();
        }
    }
}
