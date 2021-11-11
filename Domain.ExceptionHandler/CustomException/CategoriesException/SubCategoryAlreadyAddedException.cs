using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException.CategoriesException
{
    public class SubCategoryAlreadyAdedException : BaseException
    {
        public SubCategoryAlreadyAdedException()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "SubCategory Already Added";
        }
    }
}
