using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException
{
    public class EmailAlreadyUsedException : BaseException
    {
        public EmailAlreadyUsedException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Email already is Registred in System";
        }
    }
}
