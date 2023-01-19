using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : Entity
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
        public virtual Company? Company { get; set; }

        public Order()
        {
        }

        public Order(int id, int companyId, int productId, int userId, DateTime orderDate,bool isDeleted) : this()
        {
            Id = id;
            CompanyId = companyId;
            ProductId = productId;
            UserId = userId;
            OrderDate = orderDate;
            IsDeleted = isDeleted;
        }
    }
}
