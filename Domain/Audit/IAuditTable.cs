using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Audit
{
    public interface IAuditTable
    {
        public Guid Uid { get; set; }
        DateTime CreatedDateTime { get; set; }
        DateTime? LastModifiedDateTime { get; set; }
        bool Deleted { get; set; }
    }
}
