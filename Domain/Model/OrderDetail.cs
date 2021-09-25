using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class OrderDetail
    {
        public Guid ProductsUid { get; set; }
        public Product Products { get; set; }

        public Guid OrdersUid { get; set; }
        public Order Orders { get; set; }
    }
}
