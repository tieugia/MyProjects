#pragma checksum "D:\MyProjects\Demo\WebApp\WebApp\Views\Home\_Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8627074b4781bd52b3950bd634bc6decf3dce85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Show), @"mvc.1.0.view", @"/Views/Home/_Show.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8627074b4781bd52b3950bd634bc6decf3dce85", @"/Views/Home/_Show.cshtml")]
    public class Views_Home__Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebApp.Models.Result>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div id=\"sheet\">\r\n");
#nullable restore
#line 3 "D:\MyProjects\Demo\WebApp\WebApp\Views\Home\_Show.cshtml"
     foreach (WebApp.Models.Result item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <h2 class=\"card-title\"><a href=\"/\">");
#nullable restore
#line 7 "D:\MyProjects\Demo\WebApp\WebApp\Views\Home\_Show.cshtml"
                                              Write(item.ProvinceName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 7 "D:\MyProjects\Demo\WebApp\WebApp\Views\Home\_Show.cshtml"
                                                                   Write(item.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h2>\r\n            </div>\r\n            <div class=\"card-body\">\r\n                ");
#nullable restore
#line 10 "D:\MyProjects\Demo\WebApp\WebApp\Views\Home\_Show.cshtml"
           Write(Html.Raw(string.Format(ViewBag.patterns[item.PatternId - 1].Show, item.Numbers)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 13 "D:\MyProjects\Demo\WebApp\WebApp\Views\Home\_Show.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebApp.Models.Result>> Html { get; private set; }
    }
}
#pragma warning restore 1591
