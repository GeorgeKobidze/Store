using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Product : AuditTable
    {
        [MaxLength(200)]
        [Required]
        public string ProductCode { get; set; }
        [MaxLength(200)]
        [Required]
        public string ProductName { get; set; }
        [MaxLength(500)]
        [Required]
        public string ProductDesc { get; set; }     
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public ICollection<ProductFile> ProductFiles { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }


    }
}
