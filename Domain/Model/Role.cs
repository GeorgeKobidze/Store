using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Audit;

namespace Domain.Model
{
    public class Role : AuditTable
    {
        [MaxLength(200)]
        [Required]
        public string RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
