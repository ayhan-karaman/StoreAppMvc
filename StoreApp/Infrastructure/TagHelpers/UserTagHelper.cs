using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes ="user-role")]
    public class UserTagHelper:TagHelper
    {
        [HtmlAttributeName("user-name")]
        public string? UserName { get; set; }
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            TagBuilder ul = new TagBuilder("ul");
            ul.Attributes.Add("class", "p-0");
            var roles =  _roleManager.Roles.ToList().Select(x => x.Name);

            foreach (var role in roles)
            {
                TagBuilder li = new TagBuilder("li");
                li.Attributes.Add("class", " list-group-item");

                TagBuilder span = new TagBuilder("span");
                span.Attributes.Add("class", "badge text-bg-info rounded-pill");
                span.InnerHtml.AppendHtml($"{role} : {await _userManager.IsInRoleAsync(user, role)}");


                li.InnerHtml.AppendHtml(span);
                ul.InnerHtml.AppendHtml(li);
            }

            output.Content.AppendHtml(ul);
        }
    }
}