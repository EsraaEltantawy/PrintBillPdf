using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintBillPdf.Models
{
    public class Customer
    {

        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public System.Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public System.DateTime OrderDate { get; set; }

         public virtual ICollection<Order> Orders { get; set; }
    }
}