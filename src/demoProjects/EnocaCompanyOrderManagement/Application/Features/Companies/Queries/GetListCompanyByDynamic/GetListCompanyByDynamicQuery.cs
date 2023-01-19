using Application.Features.Companies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.GetListCompanyByDynamic
{
    public class GetListCompanyByDynamicQuery : IRequest<CompanyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetListCompanyByDynamicQueryHandler : IRequestHandler<GetListCompanyByDynamicQuery, CompanyListModel>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;

            public GetListCompanyByDynamicQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
            }

            public async Task<CompanyListModel> Handle(GetListCompanyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Company> companies = await _companyRepository.GetListByDynamicAsync(
                    request.Dynamic,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                CompanyListModel mappedCompanyListModel = _mapper.Map<CompanyListModel>(companies);

                return mappedCompanyListModel;
            }
        }
    }
}
