using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Constants
{
    public static class OperationClaims
    {
        public const string CompanyAdd = "company.add";
        public const string CompanyNameExists = "Company Name Exists.";
        public const string RequestedCompany = "Requested Company Does Not Exist.";
    }
}
