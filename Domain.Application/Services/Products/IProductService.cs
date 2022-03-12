using Domain.Infrastructure.DataTransferObjects.Request.Product;
using Domain.Infrastructure.DataTransferObjects.Response.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.Products
{
    public interface IProductService
    {
        Task<List<GetAllProductDto>> GetAllProduct();

        Task<GetProductDto> GetProduct(Guid uid);

        Task<Guid> AddProduct(AddProductDto addProduct);

        Task AddFileForPruduct(IList<IFormFile> files, Guid productUid);

        Task DeleteProduct(Guid ProductUid);
    }
}
