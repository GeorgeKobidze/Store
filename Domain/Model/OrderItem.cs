using Domain.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class OrderItem : AuditTable
    {
        public Guid ProductsUid { get; set; }
        public Product Products { get; set; }

        public int Quantity { get; set; }
        public Guid OrdersUid { get; set; }
        public Order Orders { get; set; }
    }
}
