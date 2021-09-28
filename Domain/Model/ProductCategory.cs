using Domain.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProductCategory : AuditTable
    {
        public Product Product { get; set; }
        public Category category { get; set; }
    }
}
