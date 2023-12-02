using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Models;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper: TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public Pagination PageModel { get; set; }
        public string? PageAction { get; set; }

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           if(ViewContext is not null && PageModel is not null)
           {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                result.Attributes.Add("aria-label", "Page navigation example");


                TagBuilder ul = new TagBuilder("ul");
                ul.Attributes.Add("class", "pagination");

                
                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder li = new TagBuilder("li");
                    li.AddCssClass("page-item");
                    li.AddCssClass(i == PageModel.CurrentPage ? "active" : "");


                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new {PageNumber = i});

                    

                    tag.Attributes["class"] = "page-link";
                    tag.InnerHtml.AppendHtml(i.ToString());
                    
                    li.InnerHtml.AppendHtml(tag);
                    ul.InnerHtml.AppendHtml(li);
                }
                result.InnerHtml.AppendHtml(ul);

                output.Content.AppendHtml(result);
           }
        }
    }
}