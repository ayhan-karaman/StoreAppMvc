using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDtoForInsertion categoryDto)
        {
            if(ModelState.IsValid)
            {
                _manager.CategoryService.CreateCategory(categoryDto);
                return RedirectToAction("Index", new {area = "Admin"} );
            }
            return View();
        }
    }
}