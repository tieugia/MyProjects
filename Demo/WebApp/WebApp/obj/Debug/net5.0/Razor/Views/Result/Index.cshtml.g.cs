#pragma checksum "E:\08-2021-C#\Buoi12\WebApp\Views\Result\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da9c0ac82c7d3277cbae06a03330bfa15352b278"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Result_Index), @"mvc.1.0.view", @"/Views/Result/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da9c0ac82c7d3277cbae06a03330bfa15352b278", @"/Views/Result/Index.cshtml")]
    public class Views_Result_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebApp.Models.Result>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <a class=""btn btn-primary"" href=""result/create"">Create</a>
    <a class=""btn btn-secondary"" href=""result/insert"">Insert</a>
    <table class=""table table-bordered"">
        <thead class=""thead-dark"">
            <tr>
                <th>Id</th>
                <th>Date</th>
                <th>Province</th>
                <th>Detail</th>
                <th>Edit</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 15 "E:\08-2021-C#\Buoi12\WebApp\Views\Result\Index.cshtml"
             foreach (WebApp.Models.Result item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 18 "E:\08-2021-C#\Buoi12\WebApp\Views\Result\Index.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <!-- mm: Minute, MM: Month -->\r\n                    <td>");
#nullable restore
#line 20 "E:\08-2021-C#\Buoi12\WebApp\Views\Result\Index.cshtml"
                   Write(item.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "E:\08-2021-C#\Buoi12\WebApp\Views\Result\Index.cshtml"
                   Write(item.ProvinceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 824, "\"", 855, 2);
            WriteAttributeValue("", 831, "/result/detail3/", 831, 16, true);
#nullable restore
#line 23 "E:\08-2021-C#\Buoi12\WebApp\Views\Result\Index.cshtml"
WriteAttributeValue("", 847, item.Id, 847, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Detail3</a>\r\n                    </td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 923, "\"", 951, 2);
            WriteAttributeValue("", 930, "/result/edit/", 930, 13, true);
#nullable restore
#line 25 "E:\08-2021-C#\Buoi12\WebApp\Views\Result\Index.cshtml"
WriteAttributeValue("", 943, item.Id, 943, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-edit\"></i></a></td>\r\n                </tr>\r\n");
#nullable restore
#line 27 "E:\08-2021-C#\Buoi12\WebApp\Views\Result\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
