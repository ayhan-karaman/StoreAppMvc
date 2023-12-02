using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
       private readonly IServiceManager _manager;
       private readonly IMapper _mapper;

        public ProductController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _manager.ProductService.GetAllProducts(false);
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDtoForInsertion, IFormFile file)
        {
           if(ModelState.IsValid)
           {
                // file operation 
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "products", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDtoForInsertion.ImageUrl = string.Concat("/img/products/", file.FileName);
                _manager.ProductService.CreateOneProduct(productDtoForInsertion);
                return RedirectToAction("Index");
           }
           return View();
        }



        public IActionResult Update([FromRoute(Name ="id")] int id)
        {
            
            ViewBag.Categories = GetCategoriesSelectList();
            var product =  _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDtoForUpdate, IFormFile file)
        {
            if(ModelState.IsValid)
           {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "products", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDtoForUpdate.ImageUrl = string.Concat("/img/products/", file.FileName);
                _manager.ProductService.UpdateOneProduct(productDtoForUpdate);
                return RedirectToAction("Index");
           }
           return View();
        }

         public IActionResult Delete([FromRoute] int id)
         {
             _manager.ProductService.DeleteOneProduct(id);
             return RedirectToAction("Index"); 
         }

         private SelectList GetCategoriesSelectList()
         {
            var categories =  _manager.CategoryService.GetAllCategories(false);
            return new SelectList(categories, "Id", "Name");
         }

    }
}