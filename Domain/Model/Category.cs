using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Category : AuditTable
    {
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
