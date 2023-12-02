using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.IdentityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            return View(
                new UserDtoForCreation()
                {
                    Roles = new HashSet<string>(_manager.AuthService.Roles.Select(x => x.Name).ToList())
                }
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            var result = await _manager.AuthService.CreateUserAsync(userDto);
            if(!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                        ModelState.AddModelError("", err.Description);
                }
                return View();
            }
            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _manager.AuthService.GetOneUserForUpdateAsync(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
        {
            if(ModelState.IsValid)
            {
                await _manager.AuthService.UpdateUserAsyc(userDto);
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public IActionResult ResetPassword([FromRoute(Name = "id")] string id)
        {

            return View(new ResetPasswordDto{ UserName = id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto passwordDto)
        {
            var result = await _manager.AuthService.ResetPassword(passwordDto);

            return result.Succeeded ? RedirectToAction("Index") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] UserDto userDto)
        {
             var result = await _manager.AuthService.DeleteOneUserAsync(userDto.UserName);
             return result.Succeeded ? RedirectToAction("Index") : View();
             
        }
    }
}