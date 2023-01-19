using Application.Features.Companies.Dtos;
using Application.Features.Companies.Models;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.GetByIdCompany
{
    public class GetByIdCompanyQuery : IRequest<CompanyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery, CompanyGetByIdDto>
        {

            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;
            private readonly CompanyBusinessRules _companyBusinessRules;

            public GetByIdCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper, CompanyBusinessRules companyBusinessRules)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
                _companyBusinessRules = companyBusinessRules;
            }

            public async Task<CompanyGetByIdDto> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
            {
               
                Company? company = await _companyRepository.GetAsync(x=> x.Id == request.Id && x.IsDeleted == false);
                 _companyBusinessRules.CompanyShouldExistWhenRequested(company);
                CompanyGetByIdDto mappedCompanyDto= _mapper.Map<CompanyGetByIdDto>(company);
                return mappedCompanyDto;
            }
        }
    }
}
