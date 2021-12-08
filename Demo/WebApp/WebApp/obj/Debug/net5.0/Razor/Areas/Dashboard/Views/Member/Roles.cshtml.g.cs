#pragma checksum "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1943180cf54aa94d47943549f3f845e179c0022c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Dashboard_Views_Member_Roles), @"mvc.1.0.view", @"/Areas/Dashboard/Views/Member/Roles.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1943180cf54aa94d47943549f3f845e179c0022c", @"/Areas/Dashboard/Views/Member/Roles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24d023925b0a50c8ea0e11e0aa6de24e1be950a0", @"/Areas/Dashboard/Views/_ViewImports.cshtml")]
    public class Areas_Dashboard_Views_Member_Roles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Member>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <div class=\"card-title\">\r\n            ");
#nullable restore
#line 5 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
       Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - <b>");
#nullable restore
#line 5 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
                            Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b> 
        </div>
    </div>
    <div class=""card-body"">
        <table class="" table table-bordered"">
            <thead class=""table-dark"">
                <tr>
                    <th>Role Name</th>
                    <th>Checked</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 17 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
                 foreach(Role item in ViewBag.roles)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 20 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
                       Write(item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 22 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
                             if (item.Checked)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <input checked type=\"checkbox\" name=\"c\"");
            BeginWriteAttribute("value", " value=\"", 790, "\"", 810, 1);
#nullable restore
#line 24 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
WriteAttributeValue("", 798, item.RoleId, 798, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 25 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <input type=\"checkbox\" name=\"c\"");
            BeginWriteAttribute("value", " value=\"", 975, "\"", 995, 1);
#nullable restore
#line 28 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
WriteAttributeValue("", 983, item.RoleId, 983, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 29 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 33 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<script>
    $('input[name=""c""]').click(function () {
        //console.log($(this).val());
        var rid = $(this).val();
        $.post('/dashboard/member/roles', { roleId: rid, memberId: '");
#nullable restore
#line 42 "C:\Users\ADMIN\Downloads\Module4b\WebApp\WebApp\Areas\Dashboard\Views\Member\Roles.cshtml"
                                                               Write(Model.MemberId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' }, (d) => {\r\n            console.log(d);\r\n        });\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Member> Html { get; private set; }
    }
}
#pragma warning restore 1591
