#pragma checksum "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a1e55bd3f63b301fccec1680e5c735afaa9efb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PassbookManagement.Areas.Customers.Views.Transaction.Areas_Customers_Views_Transaction_Delete), @"mvc.1.0.view", @"/Areas/Customers/Views/Transaction/Delete.cshtml")]
namespace PassbookManagement.Areas.Customers.Views.Transaction
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
#line 2 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/_ViewImports.cshtml"
using PassbookManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/_ViewImports.cshtml"
using PassbookManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/_ViewImports.cshtml"
using PassbookManagement.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a1e55bd3f63b301fccec1680e5c735afaa9efb4", @"/Areas/Customers/Views/Transaction/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b309d3a76a8574937f71e6c223c56d8bc582d21f", @"/Areas/Customers/Views/_ViewImports.cshtml")]
    public class Areas_Customers_Views_Transaction_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PassbookManagement.Models.Transaction>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Transaction</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Passbook));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayFor(model => model.Passbook.PassbookId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayFor(model => model.Employee.EmployeeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TransactionMethod));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayFor(model => model.TransactionMethod));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TransactionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayFor(model => model.TransactionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsViolation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsViolation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ReleaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayFor(model => model.ReleaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SpendingAccount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
       Write(Html.DisplayFor(model => model.SpendingAccount.AccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1e55bd3f63b301fccec1680e5c735afaa9efb412155", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2a1e55bd3f63b301fccec1680e5c735afaa9efb412420", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 65 "/Users/thinhtq/Desktop/Nhom17_18521451_18521468_18520445_18521153__17520308_17520227/PassbookManagement/PassbookManagement/Areas/Customers/Views/Transaction/Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TransactionId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1e55bd3f63b301fccec1680e5c735afaa9efb414286", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PassbookManagement.Models.Transaction> Html { get; private set; }
    }
}
#pragma warning restore 1591
