using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException.CustomerException
{
    public class CustomerNotFoundException : BaseException
    {
        public CustomerNotFoundException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Customer Not Found";
        }
    }
}
