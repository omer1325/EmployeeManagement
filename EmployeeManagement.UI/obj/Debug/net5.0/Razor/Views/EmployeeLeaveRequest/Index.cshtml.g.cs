#pragma checksum "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85b4fae9d9fb5693a3c6e39c507c020e9d59e6c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EmployeeManagement.UI.Pages.EmployeeLeaveRequest.Views_EmployeeLeaveRequest_Index), @"mvc.1.0.view", @"/Views/EmployeeLeaveRequest/Index.cshtml")]
namespace EmployeeManagement.UI.Pages.EmployeeLeaveRequest
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85b4fae9d9fb5693a3c6e39c507c020e9d59e6c9", @"/Views/EmployeeLeaveRequest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc2b25f79d4e46e1bc0a545b207a59769437b873", @"/Views/_ViewImports.cshtml")]
    public class Views_EmployeeLeaveRequest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EmployeeManagement.Common.ViewModels.EmployeeLeaveRequestVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EmployeeLeaveRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-xs btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <h3>\r\n        <small>\r\n            <i class=\"ace-icon fa fa-angle-double-right\"></i>\r\n            Çalışan İzin Talep Listesi\r\n        </small>\r\n    </h3>\r\n</div>\r\n\r\n<br />\r\n<div class=\"col-6 text-left text-white\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85b4fae9d9fb5693a3c6e39c507c020e9d59e6c95573", async() => {
                WriteLiteral("Talep Ekle");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<br />
<div class=""row"">
    <div class=""col-xs-12"">
        <table id=""simple-table"" class=""table  table-bordered table-hover"">
            <thead>
                <tr>
                    <th>Başlangıç Tarihi</th>
                    <th>Bitiş Tarihi</th>
                    <th>Sebep</th>
                    <th>Durum</th>
                    <th>İşlemler</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 36 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 39 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                       Write(item.StartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 40 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                        Write(item.EndDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                       Write(item.LeaveTypeText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 42 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                         if (item.ApprovedStatus == Common.ConstantModels.EnumEmployeeLeaveRequestStatus.Send_Approved)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td style=\"color: aqua\">Onaya Gönderildi</td>\r\n");
#nullable restore
#line 45 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                        }
                        else if(item.ApprovedStatus == Common.ConstantModels.EnumEmployeeLeaveRequestStatus.Approved)
                        { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td style=\"color:green\">Onaylandı</td>\r\n");
#nullable restore
#line 49 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                        }
                        else 
                        { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td style=\"color: red\">Reddedildi</td>\r\n");
#nullable restore
#line 53 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        \r\n");
#nullable restore
#line 55 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                         if (item.ApprovedStatus != Common.ConstantModels.EnumEmployeeLeaveRequestStatus.Approved)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                <div class=\"hidden-sm hidden-xs btn-group\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85b4fae9d9fb5693a3c6e39c507c020e9d59e6c910830", async() => {
                WriteLiteral("\r\n                                        <i class=\"ace-icon fa fa-pencil bigger-120\"></i>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                                                                                                                             WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <a class=\"btn btn-xs btn-danger btnRemove\" data-id=\"");
#nullable restore
#line 62 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                                                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                                        <i class=""ace-icon fa fa-trash bigger-120""></i>
                                    </a>
                                    <button class=""btn btn-xs btn-warning"">
                                        <i class=""ace-icon fa fa-flag bigger-120""></i>
                                    </button>
                                </div>
                            </td>
");
#nullable restore
#line 70 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 72 "C:\Users\omer\source\repos\EmployeeManagement\EmployeeManagement.UI\Views\EmployeeLeaveRequest\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div><!-- /.span -->\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            $("".btnRemove"").on(""click"", function () {
                var id = $(this).data(""id"");
                swal({
                    title: 'Silmek İstediğinize Emin Misiniz?',
                    text: 'Silinen Data Geri Alınamaz!',
                    icon: 'warning',
                    buttons: true,
                    dangerMode: true
                }).then((willDelete) => {
                    if (willDelete) {
                        $.ajax({
                            type: ""DELETE"",
                            url: ""/EmployeeLeaveRequest/Delete/"" + id,
                            success: function (data) {
                                if (data.success) {
                                    toastr.success(data.message);
                                    location.reload();
                                } else {
                                    toastr.error(data.message);
            ");
                WriteLiteral("                    }\r\n                            }\r\n                        });\r\n                    }\r\n\r\n                });\r\n            });\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EmployeeManagement.Common.ViewModels.EmployeeLeaveRequestVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
