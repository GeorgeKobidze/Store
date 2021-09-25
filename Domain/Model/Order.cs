using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductCount { get; set; }
        public decimal Sum { get; set; }
        public string OrderStatus { get; set; }
        public string Comment { get; set; }
    }
}
