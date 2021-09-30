using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException
{
    public class RoleNotFoundException : BaseException
    {
        public RoleNotFoundException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Role Not Found";
        }
    }
}
