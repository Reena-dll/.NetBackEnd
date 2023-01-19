using Application.Features.Companies.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Rules
{
    public class CompanyBusinessRules
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyBusinessRules(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task CompanyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Company> result = await _companyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(OperationClaims.CompanyNameExists);
        }

        public void CompanyShouldExistWhenRequested(Company company)
        {
            if (company == null) throw new BusinessException(OperationClaims.RequestedCompany);
        }

        public async Task CompanyShouldExistWhenUpdated(int id)
        {
            Company? result = await _companyRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(OperationClaims.RequestedCompany);
        }

        
    }
}
