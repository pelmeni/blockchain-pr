#pragma checksum "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbc7851464564d6bc168736d56ab0689ae7ac2ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Energy_MySensors), @"mvc.1.0.view", @"/Views/Energy/MySensors.cshtml")]
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
#line 1 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbc7851464564d6bc168736d56ab0689ae7ac2ed", @"/Views/Energy/MySensors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac7a6a20369a094c1643b76f0e92e19ec3cef6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Energy_MySensors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication5.Models.EnergyUserSensor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbc7851464564d6bc168736d56ab0689ae7ac2ed3450", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 9 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayNameFor(model => model.UserSensorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 12 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayNameFor(model => model.SensorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayNameFor(model => model.SensorText));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayNameFor(model => model.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayNameFor(model => model.LastCounterValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayNameFor(model => model.LastCounterValueDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 33 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserSensorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayFor(modelItem => item.SensorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayFor(modelItem => item.SensorText));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastCounterValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastCounterValueDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 59 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.ActionLink("Details", "Details", new {  sensorId=item.SensorId  }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 60 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = item.UserSensorId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n");
#nullable restore
#line 61 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
                 using (Html.BeginForm("Delete", "EnergyController", FormMethod.Post, new { id = "SensorsForm", method = "post", action = $"/Energy/Delete/{item.UserSensorId}" }))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
               Write(Html.ActionLink("Delete", "Delete", "EnergyController", new { id = item.UserSensorId }, new { @class = "postLink", onclick = "return false;" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
                                                                                                                                                                    
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n        </tr>\r\n");
#nullable restore
#line 67 "C:\dev\blockchain-pr\Console4_300\WebApplication5\Views\Energy\MySensors.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication5.Models.EnergyUserSensor>> Html { get; private set; }
    }
}
#pragma warning restore 1591