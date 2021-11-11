using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException.CategoriesException
{
    public class SubCategoryAlreadyAddedException : BaseException
    {
        public SubCategoryAlreadyAddedException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Category Already Added";
        }
    }
}
