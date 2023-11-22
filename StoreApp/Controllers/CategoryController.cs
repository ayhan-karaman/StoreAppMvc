using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var categories = _manager.CategoryService.GetAllCategories(false);
            return View(categories);
        }

        
    }
}