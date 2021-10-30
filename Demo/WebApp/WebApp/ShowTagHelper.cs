using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class ShowTagHelper : TagHelper
    {
        public List<Number> Numbers { get; set; }
        public string Value { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Regex regex = new Regex(@"{(\d+)}");
            output.Content.SetHtmlContent(regex.Replace(Value, (Match m) =>
            {
                Number obj = Numbers[int.Parse(m.Groups[1].Value)];
                return $"<span class=\"e\" v=\"{obj.Id}\">{obj.Value}</span>";
            }));
        }
    }
}
