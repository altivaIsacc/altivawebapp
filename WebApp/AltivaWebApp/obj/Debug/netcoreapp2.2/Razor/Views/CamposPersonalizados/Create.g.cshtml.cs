#pragma checksum "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "107c7a98f4cf54588a3d16e217d17111e40c66cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CamposPersonalizados_Create), @"mvc.1.0.view", @"/Views/CamposPersonalizados/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CamposPersonalizados/Create.cshtml", typeof(AspNetCore.Views_CamposPersonalizados_Create))]
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
#line 1 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using AltivaWebApp;

#line default
#line hidden
#line 2 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using AltivaWebApp.Domains;

#line default
#line hidden
#line 3 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using AltivaWebApp.GEDomain;

#line default
#line hidden
#line 4 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using AltivaWebApp.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#line 6 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 7 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107c7a98f4cf54588a3d16e217d17111e40c66cf", @"/Views/CamposPersonalizados/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"126a05e3a3a8e0538c9347fb29de305015eab212", @"/Views/_ViewImports.cshtml")]
    public class Views_CamposPersonalizados_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AltivaWebApp.ViewModels.CamposPersonalizadosViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CamposPersonalizados", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
            BeginContext(106, 127, true);
            WriteLiteral("\r\n<div class=\" col-md-12\" ><div id=\"mensaje\" hidden class=\"alert alert-danger col-md-4\">Quito un campo</div></div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(233, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "107c7a98f4cf54588a3d16e217d17111e40c66cf6199", async() => {
                BeginContext(277, 5, true);
                WriteLiteral("Atras");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(286, 969, true);
            WriteLiteral(@"
</div>
<h4>Seleccione el campo que desea agregar</h4>
<hr />
<div class=""row"">
    <div class=""col-md-6"">
        <div class=""col-md-3"">
            <div class=""form-group "">
                <button class=""btn btn-dark"" id=""fechaHora"">Fecha y hora</button>
            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""form-group "">
                <button class=""btn btn-dark"" id=""CheckBox"">Check Box </button>
            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""form-group "">
                <button class=""btn btn-dark"" id=""TextArea"">Texto Grande </button>
            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""form-group "">
                <button class=""btn btn-dark"" id=""Text""> Texto Pequeño </button>
            </div>
        </div>
    </div>

    <div class=""col-md-6 "">
        <h2>Campos Personalizados agregados</h2>
        ");
            EndContext();
            BeginContext(1255, 438, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "107c7a98f4cf54588a3d16e217d17111e40c66cf8658", async() => {
                BeginContext(1319, 367, true);
                WriteLiteral(@"
            <div class=""panel panel-default pre-scrollable"" style=""height:100rem;"" id=""panelCampos"">
                <div class=""col-md-4"">
                    <ul id=""ul""></ul>

                </div>
            </div>
            <button style=""font-size:2rem;"" type=""submit"" class=""btn btn-link"">Guardar&nbsp;<i class=""fas fa-save""></i></button>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1693, 2351, true);
            WriteLiteral(@"
    </div>
</div>





<script>

    var i = 0;
    $(document).ready(function () {
  
        $(""#fechaHora"").click(function () {

            $(""#ul"").append('<li id=li' + i + '><input hidden asp-for=""tipo[]"" name=""tipo[]"" id=""fechayHora' + i + '"" value=""datetime-local""/>Nombre del campo fecha y hora: <input type=""text""  required asp-for=""nombre[]"" name=""nombre[]"" class=""form-control input-mini"" id=""' + i + '"" /><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></li>');
            i++;
        });
        $(""#CheckBox"").click(function () {

            $(""#ul"").append('<li id=li' + i + '><input hidden  asp-for=""tipo[]"" name=""tipo[]""  id=""checkbox' + i + '"" value=""checkbox""/>Nombre del campo CheckBox: <input type=""text"" required  asp-for=""nombre[]"" name=""nombre[]"" class=""form-control input-mini"" id=' + i + '/><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></li>');
            i++;
        ");
            WriteLiteral(@"});
        $(""#TextArea"").click(function () {

            $(""#ul"").append('<li id=li' + i + '><input hidden asp-for=""tipo[]"" name=""tipo[]"" id=""textArea' + i + '"" value=""textArea""/>Nombre del Texto Grande: <input required type=""text""  asp-for=""nombre[]"" name=""nombre[]"" class=""form-control input-mini"" id=' + i + '/><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></li>');
            i++;
        });
        $(""#Text"").click(function () {

            $(""#ul"").append('<li id=li' + i + '><input hidden asp-for=""tipo[]"" name=""tipo[]"" id=""text' + i + '"" value=""text""/>Nombre del texto: <input type=""text"" required asp-for=""nombre[]"" name=""nombre[]"" class=""form-control input-mini"" id=' + i + '/><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></li>');
            i++;
        });
    });
    function eliminar(id) {
        var opcion = confirm(""Deseas eliminarlo"");
        var mensaje;
        if (opcion ==");
            WriteLiteral(@" true) {
            $(""#ul #li"" + id + """").remove();
          
            $('#mensaje').show();

            i--;
            setTimeout(function () {
                $(""#mensaje"").fadeOut(10);
            }, 2000);

        } else {
            return;
        }
   

    }
</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AltivaWebApp.ViewModels.CamposPersonalizadosViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
