using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Store.Web.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok();
        }

    
    }
}
