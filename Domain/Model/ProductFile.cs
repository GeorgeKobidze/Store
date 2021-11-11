using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProductFile : AuditTable
    {
        [MaxLength(100)]
        [Required]
        public string FileName { get; set; }
        [MaxLength(200)]
        [Required]
        public string FilePath { get; set; }

        public Guid ProductUid { get; set; }
        public Product Product { get; set; }
    }
}
