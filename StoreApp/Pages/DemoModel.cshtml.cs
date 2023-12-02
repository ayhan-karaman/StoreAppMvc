using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public string? FullName => HttpContext.Session.GetString("name") ?? " ...";
        public void OnGet()
        {
            
        }
        public void OnPost(string name)
        {
            HttpContext.Session.SetString("name", name);
        }
    }
}