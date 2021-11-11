using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.DataTransferObjects.Request.Category
{
    public class AddCategoriesDto
    {
        public string CategoryName { get; set; }
        public List<SubCategoriesDto> SubCategories { get; set; }
    }

    public  class SubCategoriesDto
    {
        public string SubCategoryName { get; set; }
    }
}
