#pragma checksum "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4110a8e76383e0f67b8ea3693a3e0d7065824eab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inmueble_Details), @"mvc.1.0.view", @"/Views/Inmueble/Details.cshtml")]
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
#line 1 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\_ViewImports.cshtml"
using Proyecto_InmobiliariaVaras;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\_ViewImports.cshtml"
using Proyecto_InmobiliariaVaras.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4110a8e76383e0f67b8ea3693a3e0d7065824eab", @"/Views/Inmueble/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dc72adcd604e435cf7da09af3706694bad24e98", @"/Views/_ViewImports.cshtml")]
    public class Views_Inmueble_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Proyecto_InmobiliariaVaras.Models.Inmueble>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
  
    ViewData["Title"] = "Detalles";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalles</h1>\r\n\r\n<div>\r\n    <h4>Inmueble</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdInmueble));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdInmueble));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DireccionInmueble));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayFor(model => model.DireccionInmueble));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ambientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ambientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Superficie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayFor(model => model.Superficie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayFor(model => model.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayFor(model => model.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdPropietario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdPropietario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 58 "C:\Users\Usuario\source\repos\Proyecto_InmobiliariaVaras\Proyecto_InmobiliariaVaras\Views\Inmueble\Details.cshtml"
Write(Html.ActionLink("Editar", "Edit", new { id = Model.IdInmueble }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4110a8e76383e0f67b8ea3693a3e0d7065824eab9266", async() => {
                WriteLiteral("Volver al listado");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Proyecto_InmobiliariaVaras.Models.Inmueble> Html { get; private set; }
    }
}
#pragma warning restore 1591
