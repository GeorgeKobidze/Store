using Domain.Infrastructure.Services.UnitOfWork;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.ProductCategories
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork<ProductCategory> _unitOfWork;

        public ProductCategoryService(IUnitOfWork<ProductCategory> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async  Task AddProductCategory(Product product, Category category)
        {
            var prod = new ProductCategory()
            {
                Category = category,
                Product = product
            };

            await _unitOfWork.Repository.Add(prod);
            await _unitOfWork.CommitAsync();
        }
    }
}
