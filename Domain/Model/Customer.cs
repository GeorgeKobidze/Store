using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Customer : AuditTable
    {
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [MaxLength(20)]
        [Required]
        public string Mobile { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
