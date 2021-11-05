using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException.UserException
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "User Not Found";
        }
    }
}
