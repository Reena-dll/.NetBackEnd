using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Dtos
{
    public class UpdatedCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public TimeSpan OrderStartDate { get; set; }
        public TimeSpan OrderFinishDate { get; set; }

    }
}
