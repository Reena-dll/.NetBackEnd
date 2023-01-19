using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Constants
{
    public static class OperationClaims
    {
        public const string ProductAdd = "product.add";
        public const string ProductNameExists = "Product Name Exists.";
        public const string RequestedProduct = "Requested Product Does Not Exist.";
        public const string RequestedCompany = "Requested Company Does Not Exist.";
    }
}
