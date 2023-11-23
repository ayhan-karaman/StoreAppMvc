using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        public Cart Cart { get; set; }
        public string? ReturnUrl { get; set; } = "/";
        private readonly IServiceManager _manager;

        public CartModel(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

   
        public IActionResult OnPost(int id, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(id, false);
            if(product is not null)
            {
                Cart.AddItem(product, 1);
            } 
            return Page();
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveItem(Cart.Lines.First(x => x.Product.Id == id).Product);
            return Page();
        }
    }
}