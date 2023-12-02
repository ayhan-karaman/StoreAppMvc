using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;


namespace StoreApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductsController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameter parameter)
        {
            ViewBag.CategoryId = parameter.CategoryId is null ? null : parameter.CategoryId;
            var products = _manager.ProductService.GetAllProductsWithDetails(parameter,false);
            var pagination = new Pagination()
            {
                CurrentPage = parameter.PageNumber,
                ItemsPerPage = parameter.PageSize,
                TotalItems  = _manager.ProductService.GetAllProducts(false).Count()
            };
            ProductListViewModel viewModel = new()
            {
                Products = products,
                Pagination = pagination
            };
            return View(viewModel);
        }

        public IActionResult GetById([FromRoute(Name = "id")]int id)
        {
            var product = _manager.ProductService.GetOneProduct(id, false);
            return View("Details", product);
        }

       
    }
}