#pragma checksum "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6ce62eba493806c61029a0809e8c4bf6e031dd0c6463695d92a15ba356c18761"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorPage.Pages.ManageOrder.Pages_ManageOrder_ShopView), @"mvc.1.0.razor-page", @"/Pages/ManageOrder/ShopView.cshtml")]
namespace RazorPage.Pages.ManageOrder
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\_ViewImports.cshtml"
using RazorPage

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6ce62eba493806c61029a0809e8c4bf6e031dd0c6463695d92a15ba356c18761", @"/Pages/ManageOrder/ShopView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"b17737f77675187046d22b68d7fc9c75805176fcc84134f7e38880ad3aec0901", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_ManageOrder_ShopView : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "buynow", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
  
    Layout = "Shared/_AdminLayout";
    ViewData["Title"] = "Flower";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n\r\n<h1>Flower List</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n    <tr>\r\n        <th>\r\n            ");
            Write(
#nullable restore
#line 15 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
             Html.DisplayNameFor(model => model.FlowerBouquet[0].FlowerBouquetName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            Write(
#nullable restore
#line 18 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
             Html.DisplayNameFor(model => model.FlowerBouquet[0].Description)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            Write(
#nullable restore
#line 21 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
             Html.DisplayNameFor(model => model.FlowerBouquet[0].UnitPrice)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            Write(
#nullable restore
#line 24 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
             Html.DisplayNameFor(model => model.FlowerBouquet[0].UnitsInStock)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            Write(
#nullable restore
#line 27 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
             Html.DisplayNameFor(model => model.FlowerBouquet[0].Category)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            Write(
#nullable restore
#line 30 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
             Html.DisplayNameFor(model => model.FlowerBouquet[0].Supplier)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 36 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
     foreach (var item in Model.FlowerBouquet)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 40 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
                 Html.DisplayFor(modelItem => item.FlowerBouquetName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 43 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
                 Html.DisplayFor(modelItem => item.Description)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 46 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
                 Html.DisplayFor(modelItem => item.UnitPrice)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 49 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
                 Html.DisplayFor(modelItem => item.UnitsInStock)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 52 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
                 Html.DisplayFor(modelItem => item.Category.CategoryName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 55 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
                 Html.DisplayFor(modelItem => item.Supplier.SupplierName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ce62eba493806c61029a0809e8c4bf6e031dd0c6463695d92a15ba356c187619040", async() => {
                WriteLiteral("Add");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 58 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
                                                                              item.FlowerBouquetId

#line default
#line hidden
#nullable disable
            );
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
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 61 "F:\FALL2024\PRN221\Code\Project\PRN221_Project\ProjectAssRazorPage\Pages\ManageOrder\ShopView.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorPage.Pages.ManageOrder.ShopViewModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPage.Pages.ManageOrder.ShopViewModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPage.Pages.ManageOrder.ShopViewModel>)PageContext?.ViewData;
        public RazorPage.Pages.ManageOrder.ShopViewModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
