using Domain.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CustomerAddress : AuditTable
    {
        [MaxLength(50)]
        public string AddressLine1 { get; set; }
        [MaxLength(50)]
        public string AddressLine2 { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Region { get; set; }
        [MaxLength(50)]
        public string PostalCode { get; set; }

        public Customer Customer { get; set; }
    }
}
