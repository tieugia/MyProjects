#pragma checksum "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Access\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bf0fd0ae0b484907829af2b1a015fce037d1c11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Dashboard_Views_Access_Index), @"mvc.1.0.view", @"/Areas/Dashboard/Views/Access/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bf0fd0ae0b484907829af2b1a015fce037d1c11", @"/Areas/Dashboard/Views/Access/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24d023925b0a50c8ea0e11e0aa6de24e1be950a0", @"/Areas/Dashboard/Views/_ViewImports.cshtml")]
    public class Areas_Dashboard_Views_Access_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Access>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <a href=""/dashboard/access/create"" class=""btn btn-primary"">Create</a>
<table class=""table table-bordered"">
    <thead class=""table-dark"">
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Role</th>
            <th>Url</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 13 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Access\Index.cshtml"
         foreach(var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 16 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Access\Index.cshtml"
                   Write(item.AccessId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 17 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Access\Index.cshtml"
                   Write(item.AccessName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 18 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Access\Index.cshtml"
                   Write(item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 19 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Access\Index.cshtml"
                   Write(item.AccessUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 21 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Access\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Access>> Html { get; private set; }
    }
}
#pragma warning restore 1591
