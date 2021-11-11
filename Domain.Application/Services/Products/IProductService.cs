using Domain.Infrastructure.DataTransferObjects.Request.Product;
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
        Task<Guid> AddProduct(AddProductDto addProduct);

        Task AddFileForPruduct(IList<IFormFile> files, Guid productUid);
    }
}
