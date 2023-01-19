using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Constants
{
    public static class OperationClaims
    {
        public const string OrderAdd = "Order.add";
        public const string RequestedOrder = "Requested Order Does Not Exist.";
        public const string ProductShouldExistWhenOrderCreated = "Product Should Exists When Order Created";
        public const string CompanyShouldExistWhenOrderCreated = "Company Should Exists When Order Created";
        public const string UserShouldExistWhenOrderCreated = "User Should Exists When Order Created";
        public const string UnapprovedCompanyError = "Unapproved Company Error";
        public const string ThisProductDoesNotBelongToThatCompany = "This product does not belong to that company.";
        public const string DateControl = "The company does not take orders during these hours.";

    }
}
