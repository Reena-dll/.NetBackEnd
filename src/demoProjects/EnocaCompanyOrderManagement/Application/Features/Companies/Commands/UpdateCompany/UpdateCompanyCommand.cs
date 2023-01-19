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

namespace Application.Features.Companies.Commands.UpdateCompany
{
	public class UpdateCompanyCommand : IRequest<UpdatedCompanyDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Status { get; set; }
		public TimeSpan OrderStartDate { get; set; }
		public TimeSpan OrderFinishDate { get; set; }


		public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, UpdatedCompanyDto>
		{
			private readonly ICompanyRepository _companyRepository;
			private readonly IMapper _mapper;
			private readonly CompanyBusinessRules _companyBusinessRules;

			public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, CompanyBusinessRules companyBusinessRules)
			{
				_companyRepository = companyRepository;
				_mapper = mapper;
				_companyBusinessRules = companyBusinessRules;
			}

			public async Task<UpdatedCompanyDto> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
			{
				await _companyBusinessRules.CompanyShouldExistWhenUpdated(request.Id);

				Company mappedCompany = _mapper.Map<Company>(request);
				Company updatedCompany = await _companyRepository.UpdateAsync(mappedCompany);
				UpdatedCompanyDto updatedCompanyDto = _mapper.Map<UpdatedCompanyDto>(updatedCompany);


				return updatedCompanyDto;
			}
		}
	}
}
