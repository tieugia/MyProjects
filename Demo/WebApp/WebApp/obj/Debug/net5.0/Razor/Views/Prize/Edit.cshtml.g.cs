#pragma checksum "E:\08-2021-C#\Buoi12\WebApp\Views\Prize\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c703e5d37aca3282986559566df185fa875d0b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prize_Edit), @"mvc.1.0.view", @"/Views/Prize/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c703e5d37aca3282986559566df185fa875d0b2", @"/Views/Prize/Edit.cshtml")]
    public class Views_Prize_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.Models.Prize>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<form method=\"post\">\r\n    <div>\r\n        <label>Prize</label>\r\n");
            WriteLiteral("        <input type=\"text\" name=\"name\"");
            BeginWriteAttribute("value", " value=\"", 184, "\"", 203, 1);
#nullable restore
#line 6 "E:\08-2021-C#\Buoi12\WebApp\Views\Prize\Edit.cshtml"
WriteAttributeValue("", 192, Model.Name, 192, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n    <div>\r\n        <button>Save Changes</button>\r\n    </div>\r\n</form>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Models.Prize> Html { get; private set; }
    }
}
#pragma warning restore 1591
