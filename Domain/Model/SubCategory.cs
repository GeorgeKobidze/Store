using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SubCategory : AuditTable
    {
        [MaxLength(50)]
        public string SubCategoryName { get; set; }
        public Category Category { get; set; }
    }
}
