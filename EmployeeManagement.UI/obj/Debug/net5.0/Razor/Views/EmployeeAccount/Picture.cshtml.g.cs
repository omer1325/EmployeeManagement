#pragma checksum "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeAccount\Picture.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06c576f08903d97362509da8c9d8f9ffd2236634"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EmployeeManagement.UI.Pages.EmployeeAccount.Views_EmployeeAccount_Picture), @"mvc.1.0.view", @"/Views/EmployeeAccount/Picture.cshtml")]
namespace EmployeeManagement.UI.Pages.EmployeeAccount
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
#line 1 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\_ViewImports.cshtml"
using EmployeeManagement.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\_ViewImports.cshtml"
using EmployeeManagement.Data.DbModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06c576f08903d97362509da8c9d8f9ffd2236634", @"/Views/EmployeeAccount/Picture.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc2b25f79d4e46e1bc0a545b207a59769437b873", @"/Views/_ViewImports.cshtml")]
    public class Views_EmployeeAccount_Picture : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeAccount\Picture.cshtml"
  
    ViewData["Title"] = "Picture";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<img class=\"rounded-circle w-50\"");
            BeginWriteAttribute("src", " src=\"", 92, "\"", 104, 1);
#nullable restore
#line 6 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeAccount\Picture.cshtml"
WriteAttributeValue("", 98, Model, 98, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591