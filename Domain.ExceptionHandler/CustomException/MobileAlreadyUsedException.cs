using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException
{
    public class MobileAlreadyUsedException : BaseException
    {
        public MobileAlreadyUsedException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Mobile already is Registred in System";
        }
    }
}
