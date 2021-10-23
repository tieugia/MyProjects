using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebApp.Models;

namespace WebApp
{
    public class PatternTagHelper: TagHelper
    {
        public List<Number> Numbers { get; set; }
        public string Value { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Regex regex = new Regex(@"{(\d+)}");
            output.Content.SetHtmlContent(regex.Replace(Value, (Match match) =>
            {
                Number obj = Numbers[int.Parse(match.Groups[1].Value)];
                return $"<input type=\"hidden\" name=\"numberId\" value=\"{obj.Id}\" /><input type=\"number\" name=\"value\" value=\"{obj.Value}\" />";
            }));
        }  
    }
}
