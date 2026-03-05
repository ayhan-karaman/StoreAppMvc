using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.IdentityDtos;
using Entities.Models.IdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl="/")
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            }
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            

            if (ModelState.IsValid)
            {
                AppUser? user = await _userManager.FindByNameAsync(model.Name);
                if(user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        user.LastLoginDate = DateTime.UtcNow;
                        user.LastLoginIp = HttpContext.Connection.RemoteIpAddress?.ToString();
                        await _userManager.UpdateAsync(user);
                        return Redirect(model.ReturnUrl ?? "/");
                    }
                }
                 ModelState.AddModelError("Error", "Invalid user name or password");
            }
            return View();
        }

        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl="/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {

                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                if (Request.Headers.ContainsKey("X-Forwarded-For"))
                {
                    ip = Request.Headers["X-Forwarded-For"].FirstOrDefault();
                }

            var user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    RegistrationAddress =  ip,
                   
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                 
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if(roleResult.Succeeded)
                    {
                         return RedirectToAction("Login");
                    }
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            
            return View();
        }
    
        public IActionResult AccessDenied([FromQuery(Name ="ReturnUrl")] string returnUrl)
        {
            return View();
        }
    }
}