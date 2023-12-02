using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ShowCaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ShowCaseViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public IViewComponentResult Invoke()
        {
            var products = _manager.ProductService.GetShowcaseProducts(false);
            return View(products);
        }
    }
}