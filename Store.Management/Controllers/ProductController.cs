using Domain.Application.Services.Products;
using Domain.Infrastructure.BaseController;
using Domain.Infrastructure.DataTransferObjects.Request.Product;
using Domain.Infrastructure.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Store.Management.Hubs;
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
        private IHubContext<ProductHub> _hub;

        public ProductController(IProductService productService, IHubContext<ProductHub> hub)
        {
            _productService = productService;
            _hub = hub;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProduct());
        }


        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(Guid Uid)
        {
            return Ok(await _productService.GetProduct(Uid));
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

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct( Guid productUid)
        {
            await _productService.DeleteProduct(productUid);
            return Ok();
        }

        [HttpGet("TestData")]
        public async Task<IActionResult> TestData()
        {
            List<int> data = new List<int>()
            {
                1,
                3,
                5,
                6,
                10
            };

            var timerManager = new TimerManager(() =>  _hub.Clients.All.SendAsync("TestData", data));
            return Ok();
        }




    }
}
