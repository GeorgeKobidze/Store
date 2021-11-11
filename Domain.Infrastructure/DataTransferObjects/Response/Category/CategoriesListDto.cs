using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.DataTransferObjects.Response.Category
{
    public class CategoriesListDto
    {
        public Guid Uid { get; set; }
        public string CategoryName { get; set; }
        public List<SubCatgeoriesListDto> SubCatgeoriesList { get; set; }
    }

    public class SubCatgeoriesListDto
    {
        public Guid Uid { get; set; }
        public string SubCategoryName { get; set; }
    }

}
