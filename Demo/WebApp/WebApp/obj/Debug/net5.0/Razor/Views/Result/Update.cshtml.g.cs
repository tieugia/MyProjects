#pragma checksum "D:\MyProjects\New\Demo\WebApp\WebApp\Views\Result\Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5aac8d3957c76abf61cadd6d99dd958416adb35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Result_Update), @"mvc.1.0.view", @"/Views/Result/Update.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5aac8d3957c76abf61cadd6d99dd958416adb35", @"/Views/Result/Update.cshtml")]
    public class Views_Result_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.Models.Result>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::WebApp.PatternTagHelper __WebApp_PatternTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <div class=\"card-title\">");
#nullable restore
#line 6 "D:\MyProjects\New\Demo\WebApp\WebApp\Views\Result\Update.cshtml"
                           Write(Model.Date.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 6 "D:\MyProjects\New\Demo\WebApp\WebApp\Views\Result\Update.cshtml"
                                                                Write(Model.ProvinceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n    <form class=\"card-body\" method=\"post\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pattern", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5aac8d3957c76abf61cadd6d99dd958416adb353177", async() => {
            }
            );
            __WebApp_PatternTagHelper = CreateTagHelper<global::WebApp.PatternTagHelper>();
            __tagHelperExecutionContext.Add(__WebApp_PatternTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "D:\MyProjects\New\Demo\WebApp\WebApp\Views\Result\Update.cshtml"
            WriteLiteral(ViewBag.pattern);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __WebApp_PatternTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __WebApp_PatternTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 9 "D:\MyProjects\New\Demo\WebApp\WebApp\Views\Result\Update.cshtml"
__WebApp_PatternTagHelper.Numbers = ViewBag.numbers;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("numbers", __WebApp_PatternTagHelper.Numbers, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <button class=\"btn btn-primary\">Save Changes</button>\r\n        </div>\r\n    </form>\r\n</div>");
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