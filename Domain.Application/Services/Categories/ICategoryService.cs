using Domain.Infrastructure.DataTransferObjects.Request.Category;
using Domain.Infrastructure.DataTransferObjects.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.Categories
{
    public interface ICategoryService
    {
        Task AddCategories(AddCategoriesDto addCategories);

        Task<List<CategoriesListDto>> CategoriesList();


    }
}
