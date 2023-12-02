using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes ="products")]
    public class LastestProductTagHelper : TagHelper
    {
         private readonly IServiceManager _manager;

         [HtmlAttributeName("number")]
         public int Number { get; set; }

        public LastestProductTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "bordered shadow");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class", "lead");


            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class", "fa fa-box text-primary mx-2");
            
            TagBuilder ul = new TagBuilder("ul");
            ul.Attributes.Add("class", "list-group");
            
            var products = _manager.ProductService.GetLatestProducts(Number, false);
            foreach (var product in products)
            {
                
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("class", "list-group-item list-group-item-action");
                a.Attributes.Add("href", $"/products/getbyid/{product.Id}");
                a.InnerHtml.AppendHtml(product.Name);
                
                ul.InnerHtml.AppendHtml(a);
            }


            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml("Lastest Products");

            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);

        }
    }
}