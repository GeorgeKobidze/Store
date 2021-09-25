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
    public class UserRole : AuditTable
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
