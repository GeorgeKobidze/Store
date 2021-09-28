using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Order : AuditTable
    {
        [MaxLength(100)]
        [Required]
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Sum { get; set; }
        [MaxLength(10)]
        public string OrderStatus { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDocument> OrderDocuments { get; set; }
    }
}
