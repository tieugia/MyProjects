#pragma checksum "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "811cee6298fdd6d4b5ea56b04745aec0b0a5734b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Result_Detail2), @"mvc.1.0.view", @"/Views/Result/Detail2.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"811cee6298fdd6d4b5ea56b04745aec0b0a5734b", @"/Views/Result/Detail2.cshtml")]
    public class Views_Result_Detail2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.Models.Result>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <h2 class=\"card-title\">");
#nullable restore
#line 4 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                          Write(Model.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 4 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                                        Write(Model.ProvinceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <table class=\"table table-bordered\">\r\n");
#nullable restore
#line 8 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
             foreach (WebApp.Models.Prize item in ViewBag.prizes)
            {
                if (ViewBag.numbers[item.Id].Count > 4)
                {
                    int mid = (int)Math.Ceiling(ViewBag.numbers[item.Id].Count / 2.0);

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td rowspan=\"2\">");
#nullable restore
#line 14 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 15 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                         for (int i = 0; i < mid; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th class=\"text-center\"");
            BeginWriteAttribute("colspan", " colspan=\"", 699, "\"", 718, 1);
#nullable restore
#line 17 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
WriteAttributeValue("", 709, 12/mid, 709, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 17 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                                                                   Write(ViewBag.numbers[item.Id][i].Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 18 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n                    <tr>\r\n");
#nullable restore
#line 21 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                         for (int i = mid; i < ViewBag.numbers[item.Id].Count; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th class=\"text-center\"");
            BeginWriteAttribute("colspan", " colspan=\"", 1004, "\"", 1058, 1);
#nullable restore
#line 23 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
WriteAttributeValue("", 1014, 12/(ViewBag.numbers[item.Id].Count - mid), 1014, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                                                                                                      Write(ViewBag.numbers[item.Id][i].Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 24 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 26 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 30 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 31 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                         foreach (WebApp.Models.Number num in ViewBag.numbers[item.Id])
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th class=\"text-center\"");
            BeginWriteAttribute("colspan", " colspan=\"", 1453, "\"", 1499, 1);
#nullable restore
#line 33 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
WriteAttributeValue("", 1463, 12/ViewBag.numbers[item.Id].Count, 1463, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 33 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                                                                                              Write(num.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 34 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 36 "D:\MyProjects\Demo\WebApp\WebApp\Views\Result\Detail2.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Models.Result> Html { get; private set; }
    }
}
#pragma warning restore 1591
