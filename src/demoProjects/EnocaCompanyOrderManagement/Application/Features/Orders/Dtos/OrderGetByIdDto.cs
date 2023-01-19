using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Dtos
{
    public class OrderGetByIdDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
