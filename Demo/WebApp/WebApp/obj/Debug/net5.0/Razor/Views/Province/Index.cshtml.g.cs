#pragma checksum "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0665ea6ee918692130718037978f120b00c874b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Province_Index), @"mvc.1.0.view", @"/Views/Province/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0665ea6ee918692130718037978f120b00c874b", @"/Views/Province/Index.cshtml")]
    public class Views_Province_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebApp.Models.Province>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <a href=\"province/create\" class=\"btn btn-primary\">Create</a>\r\n");
#nullable restore
#line 3 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <table class=""table table-bordered table-hover"">
        <thead class=""table-dark"">
            <tr>
                <th>Id</th>
                <th>Area</th>
                <th>Name</th>
                <th>Pattern</th>
                <th>Edit</th>
                <th>Add result</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
             foreach (WebApp.Models.Province item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 20 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
                   Write(item.AreaName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
                   Write(item.PatternId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 830, "\"", 859, 2);
            WriteAttributeValue("", 837, "province/edit/", 837, 14, true);
#nullable restore
#line 25 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
WriteAttributeValue("", 851, item.Id, 851, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-pen\"></i></a>\r\n                    </td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 972, "\"", 999, 2);
            WriteAttributeValue("", 979, "/result/add/", 979, 12, true);
#nullable restore
#line 28 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
WriteAttributeValue("", 991, item.Id, 991, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Add result</a>\r\n                    </td>\r\n                    <td>\r\n                        <a href=\"province/delete\"><i class=\"fas fa-trash\"></i></a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 34 "E:\08-2021-C#\Buoi12\WebApp\Views\Province\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebApp.Models.Province>> Html { get; private set; }
    }
}
#pragma warning restore 1591
