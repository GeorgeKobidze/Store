using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class OrderDocument : AuditTable
    {
        [MaxLength(100)]
        [Required]
        public string FileName { get; set; }
        [MaxLength(200)]
        [Required]
        public string FilePath { get; set; }

        public Order Order { get; set; }
    }
}
