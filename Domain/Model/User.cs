using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User : AuditTable
    {
        [MaxLength(200)]
        [Required]
        public string FullName { get; set; }
        [MaxLength(200)]
        [Required]
        public string Password { get; set; }
        [MaxLength(200)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(200)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(200)]
        [Required]
        public string Mobile { get; set; }
        [MaxLength(200)]
        [Required]
        public string Email { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
