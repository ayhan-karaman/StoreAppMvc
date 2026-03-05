using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    [Route("[controller]")]
    public class CheckoutController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;
       
        public CheckoutController(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            _cart = cart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            var value = new CheckoutDto();
            value.Lines = _cart.Lines;  
            return View(value);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([FromForm] CheckoutDto checkoutDto)
        {
            if(_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");

            }
            if(ModelState.IsValid)
            {
                checkoutDto.Lines = _cart.Lines.ToArray();

                if (checkoutDto.Is3DSPay)
                {
                    checkoutDto.CallBackUrl = Url.Action("PaymentCallback", "Checkout",  null, Request.Scheme);

                    var htmlContent = await _manager.PaymentService.CheckoutThreedsAsync(checkoutDto);

                    var model = new PaymentViewModel
                    {
                        HtmlContent = htmlContent
                    };
                    return View("Payment3DSecure", model);
                }
                var result = await _manager.PaymentService.CheckoutAsync(checkoutDto);
                if (result.Status == "success")
                {
                    _cart.Clear();
                    checkoutDto.Lines = null;
                    return RedirectToPage("/Complete", new {OrderId = result.BinNumber, Message = "We'll ship yout goods as soon as possible.", Status = true });
                }
               
                    return RedirectToPage("/Complete", new {OrderId = "", Message = result.ErrorMessage, Status = false});
            }
            else
            {
                return View();
            }
        }

        [HttpGet("Payment3DSecure")]
        public IActionResult Payment3DSecure(PaymentViewModel model)
        {
            return View(model);
        }


        [HttpPost("paymentcallback")]
        public async Task<IActionResult> PaymentCallback([FromForm] IFormCollection collections)
        {
            CallBackDataDto data = new(
                ConversationId: collections["conversationId"],
                Status: collections["status"],
                Locale: collections["locale"],
                PaymentId: collections["paymentId"],
                MDStatus: collections["mdStatus"]
            );

            if (data.Status == "success")
            {
                _cart.Clear();
           
                return RedirectToPage("/Complete", new { OrderId = data.ConversationId, Message = "We'll ship yout goods as soon as possible.", Status = true });
            }

            return RedirectToPage("/Complete", new { OrderId = "", Message = data.ConversationId, Status = false });
        }


    }
}