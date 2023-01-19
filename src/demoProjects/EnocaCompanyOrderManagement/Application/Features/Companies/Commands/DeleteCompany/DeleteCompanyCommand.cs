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

namespace Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<DeletedCompanyDto>
    {
        public int Id { get; set; }

        public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, DeletedCompanyDto>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;
            private readonly CompanyBusinessRules _companyBusinessRules;

            public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, CompanyBusinessRules companyBusinessRules)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
                _companyBusinessRules = companyBusinessRules;
            }

            public async Task<DeletedCompanyDto> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
            {
                await _companyBusinessRules.CompanyShouldExistWhenUpdated(request.Id);

                var deleteCompanyData = _companyRepository.Get(x => x.Id == request.Id);
                deleteCompanyData.IsDeleted = true;

                Company mappedCompany = _mapper.Map<Company>(deleteCompanyData);
                Company deletedCompany = await _companyRepository.UpdateAsync(mappedCompany);
                DeletedCompanyDto deletedCompanyDto = _mapper.Map<DeletedCompanyDto>(deletedCompany);

                return deletedCompanyDto;
            }
        }
    }
}
