#pragma checksum "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d83ead7d380aacd111716ac2fbcef4b22d3a88bd"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d83ead7d380aacd111716ac2fbcef4b22d3a88bd", @"/Views/Result/Index.cshtml")]
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
                <th><button class=""btn btn-danger"">Delete</button></th>
                <th>Id</th>
                <th>Date</th>
                <th>Province</th>
                <th>Detail</th>
                <th>Edit</th>
                <th>Update</th>
                <th>Show</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 19 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
             foreach (WebApp.Models.Result item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <input type=\"checkbox\" name=\"id\"");
            BeginWriteAttribute("value", " value=\"", 822, "\"", 838, 1);
#nullable restore
#line 23 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
WriteAttributeValue("", 830, item.Id, 830, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </td>\r\n                    <td>");
#nullable restore
#line 25 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <!-- mm: Minute, MM: Month -->\r\n                    <td>");
#nullable restore
#line 27 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
                   Write(item.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
                   Write(item.ProvinceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1125, "\"", 1156, 2);
            WriteAttributeValue("", 1132, "/result/detail3/", 1132, 16, true);
#nullable restore
#line 30 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
WriteAttributeValue("", 1148, item.Id, 1148, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Detail3</a>\r\n                    </td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1224, "\"", 1252, 2);
            WriteAttributeValue("", 1231, "/result/edit/", 1231, 13, true);
#nullable restore
#line 32 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
WriteAttributeValue("", 1244, item.Id, 1244, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-edit\"></i></a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1318, "\"", 1348, 2);
            WriteAttributeValue("", 1325, "/result/update/", 1325, 15, true);
#nullable restore
#line 33 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
WriteAttributeValue("", 1340, item.Id, 1340, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-user-edit\"></i></a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1419, "\"", 1447, 2);
            WriteAttributeValue("", 1426, "/result/show/", 1426, 13, true);
#nullable restore
#line 34 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
WriteAttributeValue("", 1439, item.Id, 1439, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-eye\"></i></a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1512, "\"", 1542, 2);
            WriteAttributeValue("", 1519, "/result/delete/", 1519, 15, true);
#nullable restore
#line 35 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
WriteAttributeValue("", 1534, item.Id, 1534, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-trash-alt\"></i></a></td>\r\n                </tr>\r\n");
#nullable restore
#line 37 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Index.cshtml"
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
