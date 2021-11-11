using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProductCategory : AuditTable
    {
        public Product Product { get; set; }
        public Category Category { get; set; }

        [Column(Order = 3)]
        public SubCategory SubCategory { get; set; }
    }
}
