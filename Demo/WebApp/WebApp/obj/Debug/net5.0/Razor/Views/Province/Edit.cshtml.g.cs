#pragma checksum "D:\MyProjects\Demo\WebApp\WebApp\Views\Province\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5915742847dac0bab9001ecd779d8f414cdfcb51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Province_Edit), @"mvc.1.0.view", @"/Views/Province/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5915742847dac0bab9001ecd779d8f414cdfcb51", @"/Views/Province/Edit.cshtml")]
    public class Views_Province_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.Models.Province>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<form method=\"post\">\r\n    <div>\r\n        <label>Area</label>\r\n        <select name=\"areaId\">\r\n            <!--Cach 1-->\r\n");
#nullable restore
#line 7 "D:\MyProjects\Demo\WebApp\WebApp\Views\Province\Edit.cshtml"
             foreach (WebApp.Models.Area item in ViewBag.areas)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <option ");
#nullable restore
#line 9 "D:\MyProjects\Demo\WebApp\WebApp\Views\Province\Edit.cshtml"
                    Write(item.Id == Model.AreaId ? "selected" : null);

#line default
#line hidden
#nullable disable
            WriteLiteral(" value=\"");
#nullable restore
#line 9 "D:\MyProjects\Demo\WebApp\WebApp\Views\Province\Edit.cshtml"
                                                                         Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 9 "D:\MyProjects\Demo\WebApp\WebApp\Views\Province\Edit.cshtml"
                                                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 17 "D:\MyProjects\Demo\WebApp\WebApp\Views\Province\Edit.cshtml"
                       
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n    </div>\r\n    <div>\r\n        <label>Name</label>\r\n        <input type=\"text\" name=\"name\"");
            BeginWriteAttribute("value", " value=\"", 783, "\"", 802, 1);
#nullable restore
#line 23 "D:\MyProjects\Demo\WebApp\WebApp\Views\Province\Edit.cshtml"
WriteAttributeValue("", 791, Model.Name, 791, 11, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Models.Province> Html { get; private set; }
    }
}
#pragma warning restore 1591
