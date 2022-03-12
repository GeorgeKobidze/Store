using AutoMapper;
using Domain.ExceptionHandler.CustomException;
using Domain.ExceptionHandler.CustomException.CategoriesException;
using Domain.Infrastructure.DataTransferObjects.Request.Category;
using Domain.Infrastructure.DataTransferObjects.Response.Category;
using Domain.Infrastructure.Services.UnitOfWork;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork<Category> _categoryUnitOfWork;
        private readonly IMapper _imapper;

        public CategoryService(IUnitOfWork<Category> categoryUnitOfWork,IMapper imapper)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
            _imapper = imapper;
        }

        public async Task AddCategories(AddCategoriesDto addCategories)
        {
            if (_categoryUnitOfWork.Repository.Where(e => e.CategoryName == addCategories.CategoryName).Any())
                throw new SubCategoryAlreadyAddedException();

            var _category = new Category()
            {
                CategoryName = addCategories.CategoryName
            };

            await _categoryUnitOfWork.Repository.Add(_category);
          


            await _categoryUnitOfWork.CommitAsync();

        }

        public async Task<List<CategoriesListDto>> CategoriesList()
        {
            var _categoriesList = new List<CategoriesListDto>();

            var _category = await _categoryUnitOfWork.Repository.Where(e => !e.Deleted).ToListAsync();

            _categoriesList =  _imapper.Map<List<CategoriesListDto>>(_category);

            return _categoriesList;
        }

      
    }
}
