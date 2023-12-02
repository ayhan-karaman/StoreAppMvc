using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductsController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult GetAllProducts()
        {
            var products = _manager.ProductService.GetAllProducts(false);
            return Ok(products);
        }
    }
}