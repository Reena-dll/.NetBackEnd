using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Product()
        {
        }

        public Product(int id,string name, int stock, int price, int companyId, bool isDeleted) : this()
        {
            Id = id;
            CompanyId = companyId;
            Name = name;
            Stock = stock;
            Price = price;
            IsDeleted = isDeleted;
        }
    }
}
