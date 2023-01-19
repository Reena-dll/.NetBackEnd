using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Company : Entity
    {

        public string Name { get; set; }
        public bool Status { get; set; }
        public TimeSpan OrderStartDate { get; set; }
        public TimeSpan OrderFinishDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Company()
        {
        }

        public Company(int id, string name, bool status, TimeSpan orderStartDate, TimeSpan orderFinishDate) : this()
        {
            Id = id;
            Name = name;
            Status = status;
            OrderStartDate = orderStartDate;
            OrderFinishDate = orderFinishDate;
        }

    }
}
