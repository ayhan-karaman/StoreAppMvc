using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("table")]
    public class TableTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "table table-hover table-bordered");

        }
    }
}