using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException
{
    public class OldPasswordIsNotCorrectEcxpetion : BaseException
    {
        public OldPasswordIsNotCorrectEcxpetion()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Old Password is Incorrect";
        }
    }
}
