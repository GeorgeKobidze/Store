using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.ProductCategories
{
    public interface IProductCategoryService
    {
        Task AddProductCategory(Product product,SubCategory subCategory,Category category);
    }
}
