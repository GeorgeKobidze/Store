using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException
{
    public class DuplicateValueInListException : BaseException
    {
        public DuplicateValueInListException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Duplicate Value Found In List";
        }
    }
}
