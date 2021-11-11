using Domain.Application.Services.Products;
using Domain.Infrastructure.BaseController;
using Domain.Infrastructure.DataTransferObjects.Request.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody]AddProductDto addProduct)
        {
            return Ok(await _productService.AddProduct(addProduct));
        }

        [HttpPost("AddFileForPruduct")]
        public async Task<IActionResult> AddFileForPruduct(IList<IFormFile> files, Guid productUid)
        {
            await _productService.AddFileForPruduct(files, productUid);
            return Ok();
        }


    }
}
