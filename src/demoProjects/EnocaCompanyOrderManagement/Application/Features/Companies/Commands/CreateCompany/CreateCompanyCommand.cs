using Application.Features.Companies.Dtos;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<CreatedCompanyDto>
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public TimeSpan OrderStartDate { get; set; }
        public TimeSpan OrderFinishDate { get; set; }


        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreatedCompanyDto>
        {

            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;
            private readonly CompanyBusinessRules _companyBusinessRules;

            public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, CompanyBusinessRules companyBusinessRules)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
                _companyBusinessRules = companyBusinessRules;
            }

            public async Task<CreatedCompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                await _companyBusinessRules.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name);

                Company mappedCompany = _mapper.Map<Company>(request);
                Company createdCompany = await _companyRepository.AddAsync(mappedCompany);
                CreatedCompanyDto createdCompanyDto = _mapper.Map<CreatedCompanyDto>(createdCompany);

                return createdCompanyDto;

            }
        }
    }
}
