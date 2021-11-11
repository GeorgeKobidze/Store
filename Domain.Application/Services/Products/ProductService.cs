using AutoMapper;
using Domain.Application.Services.ProductCategories;
using Domain.Application.Services.ProductFiles;
using Domain.ExceptionHandler.CustomException.CategoriesException;
using Domain.ExceptionHandler.CustomException.ProductException;
using Domain.Infrastructure.DataTransferObjects.Request.Product;
using Domain.Infrastructure.Services.UnitOfWork;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork<Product> _unitoOfWork;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Category> _categoryWork;
        private readonly IUnitOfWork<SubCategory> _subCategoryWork;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductFileService _productFileService;

        public ProductService(IConfiguration configuration, IUnitOfWork<Product> unitoOfWork, IMapper mapper,
            IUnitOfWork<Category> categoryWork, IUnitOfWork<SubCategory> subCategoryWork, IProductCategoryService productCategoryService,
            IProductFileService productFileService)
        {
            _configuration = configuration;
            _unitoOfWork = unitoOfWork;
            _mapper = mapper;
            _categoryWork = categoryWork;
            _subCategoryWork = subCategoryWork;
            _productCategoryService = productCategoryService;
            _productFileService = productFileService;
        }


        public async Task<Guid> AddProduct(AddProductDto addProduct)
        {
            var _product = _mapper.Map<Product>(addProduct);

            if (_unitoOfWork.Repository.Where(e => e.ProductCode == _product.ProductCode).Any())
                throw new ProductCodeAlreadyInSystemException();

            var _category = _categoryWork.Repository.Where(e => e.Uid == addProduct.ProductCategories.CategoryUid).FirstOrDefault();
            if (_category == null)
                throw new CategoryNotFoundExcpetion();

            var _subcategory = _subCategoryWork.Repository.Where(e => e.Uid == addProduct.ProductCategories.SubCategoryUid).FirstOrDefault();
            if (_category == null)
                throw new SubCategoryNotFoundException();

            await _unitoOfWork.Repository.Add(_product);
            await _productCategoryService.AddProductCategory(_product,_subcategory,_category);

            await _unitoOfWork.CommitAsync();

            return _product.Uid;
        }


        public async Task AddFileForPruduct(IList<IFormFile> files, Guid productUid)
        {
            string uploads = Path.Combine(_configuration.GetSection("FTPPaths").GetSection("ProductPath").Value, productUid.ToString());

            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(uploads, file.FileName);
                   
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        await _productFileService.AddFileForProduct(file.FileName, filePath, productUid);
                    }
                }
            }

        }
    }
}
