using Domain.Application.Services.Categories;
using Domain.Infrastructure.BaseController;
using Domain.Infrastructure.DataTransferObjects.Request.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("AddCategories")]
        public async Task<IActionResult> AddCategories(AddCategoriesDto addCategories)
        {
            await _categoryService.AddCategories(addCategories);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> CategoriesList()
        {
            return Ok(await _categoryService.CategoriesList());
        }

        [HttpGet("GetSubCatgeoriesByUid")]
        public async Task<IActionResult> GetSubCatgeoriesByUid(Guid Uid)
        {
            return Ok(await _categoryService.GetSubCatgeoriesByUid(Uid));
        }

    }
}
