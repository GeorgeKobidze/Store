using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler.CustomException.CategoriesException
{
    public class CategoryNotFoundExcpetion : BaseException
    {

        public CategoryNotFoundExcpetion()
        {
            Code = 2;
            UId = Guid.NewGuid();
            ErrorMessage = "Category Not Found";
        }
    }
}
