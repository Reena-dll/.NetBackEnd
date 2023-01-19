using Application.Features.Companies.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Models
{
    public class CompanyListModel : BasePageableModel
    {
        public List<CompanyListDto> Items { get; set; }
    }
}
