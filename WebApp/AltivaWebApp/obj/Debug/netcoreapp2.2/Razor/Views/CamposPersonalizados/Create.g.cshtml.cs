#pragma checksum "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b7e007fb87a34838577c8eb5e867c2e9e29230f"
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
#line 1 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using AltivaWebApp;

#line default
#line hidden
#line 2 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using AltivaWebApp.Domains;

#line default
#line hidden
#line 3 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using AltivaWebApp.GEDomain;

#line default
#line hidden
#line 4 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using AltivaWebApp.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#line 6 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 7 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b7e007fb87a34838577c8eb5e867c2e9e29230f", @"/Views/CamposPersonalizados/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"126a05e3a3a8e0538c9347fb29de305015eab212", @"/Views/_ViewImports.cshtml")]
    public class Views_CamposPersonalizados_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AltivaWebApp.ViewModels.CamposPersonalizadosViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Code.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Seleccione", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "fechaHora", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "checkBox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "textArea", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Lista", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
  
    ViewData["Title"] = "Crear Contacto";

#line default
#line hidden
            BeginContext(311, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6b7e007fb87a34838577c8eb5e867c2e9e29230f7531", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(341, 223, true);
            WriteLiteral("\r\n\r\n<div class=\"row col-md-12\">\r\n    <div class=\"col-sm-4\"> <h4>Seleccione el tipo que desea agregar:</h4></div>\r\n\r\n    <div class=\"col-md-4\">\r\n\r\n        <select class=\"form-control\" id=\"CamposPersonalizados\">\r\n            ");
            EndContext();
            BeginContext(564, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b7e007fb87a34838577c8eb5e867c2e9e29230f8947", async() => {
                BeginContext(598, 10, true);
                WriteLiteral("Seleccione");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(617, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(631, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b7e007fb87a34838577c8eb5e867c2e9e29230f10647", async() => {
                BeginContext(657, 12, true);
                WriteLiteral("Fecha y hora");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(678, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(692, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b7e007fb87a34838577c8eb5e867c2e9e29230f12041", async() => {
                BeginContext(717, 8, true);
                WriteLiteral("CheckBox");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(734, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(748, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b7e007fb87a34838577c8eb5e867c2e9e29230f13430", async() => {
                BeginContext(773, 12, true);
                WriteLiteral("Texto grande");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(794, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(808, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b7e007fb87a34838577c8eb5e867c2e9e29230f14824", async() => {
                BeginContext(829, 13, true);
                WriteLiteral("Texto Pequeño");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(851, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(865, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b7e007fb87a34838577c8eb5e867c2e9e29230f16219", async() => {
                BeginContext(887, 17, true);
                WriteLiteral("Lista desplegable");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(913, 826, true);
            WriteLiteral(@"
        </select>

    </div>
</div>
<hr>
<div class=""row"">


    <div class=""col-md-8 "">
        <h5>Campos Personalizados agregados.</h5>

        <div class=""panel panel-default pre-scrollable"" style=""height:100rem;"" id=""panelCampos"">
            <div class=""col-md-12"">
                <div>
                    <table class=""table table-hover"">
                        <tbody id=""ul"">
                            <tr>

                                <th>Nombre </th>
                                <td>Accion</td>
                            </tr>


                        </tbody>

                    </table>

                </div>

            </div>
        </div>


        <button type=""submit"" class=""btn btn-success"">Guardar <i class=""fas fa-save""></i></button>

        ");
            EndContext();
            BeginContext(1739, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b7e007fb87a34838577c8eb5e867c2e9e29230f18453", async() => {
                BeginContext(1785, 8, true);
                WriteLiteral("Cancelar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1797, 3661, true);
            WriteLiteral(@"


    </div>
</div>


<!-- The Modal -->
<div class=""modal fade"" id=""myModal"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">

            <!-- Modal Header -->
            <div class=""modal-header"">
                <h4 class=""modal-title""></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>

            <!-- Modal body -->
            <div class=""modal-body"">
                <div id=""crearEditarPartial"">

                </div>
            </div>

            <!-- Modal footer -->
            <div class=""modal-footer"">
                <button type=""button"" id=""guardarLista"" class=""btn btn-success"">Guardar</button>
                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Cancelar</button>
            </div>

        </div>
    </div>
</div>
<!-- The Modal 2 -->
<div class=""modal fade"" id=""myModal3"">
    <div class=""modal-dialog modal-dialog-cent");
            WriteLiteral(@"ered"">
        <div class=""modal-content"">

            <!-- Modal Header -->
            <div class=""modal-header"">
                <h4 class=""modal-title""></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>

            <!-- Modal body -->
            <div class=""modal-body"">
                <div id=""crearEditarPartial2"">

                </div>
            </div>

            <!-- Modal footer -->
            <div class=""modal-footer"">
                <button type=""button"" id=""EditarLista"" class=""btn btn-success"">Guardar</button>
                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Cancelar</button>
            </div>

        </div>
    </div>
</div><div class=""modal fade"" id=""myModal1"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">

            <!-- Modal Header -->
            <div class=""modal-header"">
                <h4 class=""modal-titl");
            WriteLiteral(@"e""></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>

            <!-- Modal body -->
            <div class=""modal-body"">
                <div id=""crearCampos"">

                </div>
            </div>

            <!-- Modal footer -->
            <div class=""modal-footer"">

                <button type=""button"" id=""guardarCampo"" class=""btn btn-success"">Guardar</button>


                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Cancelar</button>
            </div>

        </div>
    </div>

</div>
</div><div class=""modal fade"" id=""myModal2"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">

            <!-- Modal Header -->
            <div class=""modal-header"">
                <h4 class=""modal-title""></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>

            <!-- Modal body");
            WriteLiteral(@" -->
            <div class=""modal-body"">
                <div id=""crearCampos1"">

                </div>
            </div>

            <!-- Modal footer -->
            <div class=""modal-footer"">

                <button type=""button"" id=""editarCampo"" class=""btn btn-success"">Guardar</button>


                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Cancelar</button>
            </div>

        </div>
    </div>

</div>


<script>
       $.ajax({
                    headers: {
                        ""RequestVerificationToken"": '");
            EndContext();
            BeginContext(5459, 25, false);
#line 187 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(5484, 91, true);
            WriteLiteral("\'\r\n                    },\r\n                    type: \"GET\",\r\n\r\n\r\n                    url: \'");
            EndContext();
            BeginContext(5576, 63, false);
#line 192 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                     Write(Url.Action("TraerCamposPersonalizados", "CamposPersonalizados"));

#line default
#line hidden
            EndContext();
            BeginContext(5639, 1785, true);
            WriteLiteral(@"',

           success: function (data) {
               for (var i = 0; data.length; i++) {
                 //  $('#ul').append('<div style="" border-style: outset;"" class=""col-md-8"" id=li' + i + '><label hidden>asd</label>' + data[i].nombre + '</div><div class=""col-md-1"" id=li' + i + '><label hidden>Eliminar</label><button class=""btn btn-link"" onclick=""eliminar(' + data[i].id + ');""><i class=""fas fa-trash""></i></button></div><div class=""col-md-1"" ><label hidden>Eliminar</label><button class=""btn btn-link"" onclick=""Editar""><i class=""fas fa-edit""></i></button></div><div class=""col-md-12 text-danger"" id=li' + i + ' hidden>El campo fecha y hora es requerido.</div>');
                   if (data[i].tipo == ""lista"") {
                       $('#ul').append('<tr><th class=""col-md-8"" id=li' + i + '>' + data[i].nombre + '</th><td><button class=""btn btn-link"" onclick=""eliminar(' + data[i].id + ');""><i class=""fas fa-trash""></i></button></div><button class=""btn btn-link"" onclick=""EditarLista(' + data[i].id + ')"">");
            WriteLiteral(@"<i class=""fas fa-edit""></i></button></td></tr>');
                   } else {
                       $('#ul').append('<tr><th class=""col-md-8"" id=li' + i + '>' + data[i].nombre + '</th><td><button class=""btn btn-link"" onclick=""eliminar(' + data[i].id + ');""><i class=""fas fa-trash""></i></button></div><button class=""btn btn-link"" onclick=""Editar(' + data[i].id + ')""><i class=""fas fa-edit""></i></button></td></tr>');

                   }

               }
                    },

                    error: function (err, scnd) {
                        console.log(err.statusText);
                    }

    });
    function EditarLista(id) {
     $.ajax({
                    headers: {
                        ""RequestVerificationToken"": '");
            EndContext();
            BeginContext(7425, 25, false);
#line 215 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(7450, 119, true);
            WriteLiteral("\'\r\n                    },\r\n                    type: \"POST\",\r\n             data: {id:id},\r\n\r\n                    url: \'");
            EndContext();
            BeginContext(7570, 44, false);
#line 220 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                     Write(Url.Action("EditCampos", "ListaDesplegable"));

#line default
#line hidden
            EndContext();
            BeginContext(7614, 469, true);
            WriteLiteral(@"',

           success: function (data) {
           

               $('#crearEditarPartial').html(data);
                   $('#myModal').modal('show');


                    },

                    error: function (err, scnd) {
                        console.log(err.statusText);
                    }

    });
    }
    function Editar(id) {
         $.ajax({
                    headers: {
                        ""RequestVerificationToken"": '");
            EndContext();
            BeginContext(8084, 25, false);
#line 240 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(8109, 119, true);
            WriteLiteral("\'\r\n                    },\r\n                    type: \"POST\",\r\n             data: {id:id},\r\n\r\n                    url: \'");
            EndContext();
            BeginContext(8229, 48, false);
#line 245 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                     Write(Url.Action("EditCampos", "CamposPersonalizados"));

#line default
#line hidden
            EndContext();
            BeginContext(8277, 474, true);
            WriteLiteral(@"',

           success: function (data) {

                   $('#crearCampos1').html(data);
                   $('#myModal2').modal('show');


                    },

                    error: function (err, scnd) {
                        console.log(err.statusText);
                    }

    });
    }
    function cancelar() {
        var opcion = confirm(""Esta seguro que desea cancelar ?"");
        if (opcion == true) {
             var urls = '");
            EndContext();
            BeginContext(8752, 43, false);
#line 264 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                    Write(Url.Action("Index", "CamposPersonalizados"));

#line default
#line hidden
            EndContext();
            BeginContext(8795, 3154, true);
            WriteLiteral(@"';
                        window.location.href = urls;
        } else {
            return ;
        }
    }
    var i = 0;
    $(document).ready(function () {

        $(""#fechaHora"").click(function () {
            $('#ul').append('<div class=""col-md-8"" id=li' + i + '><input hidden asp-for=""tipo[]"" name=""tipo[]"" id=""fechayHora' + i + '"" value=""datetime-local""/>Nombre del campo fecha y hora: <input type=""text""  required asp-for=""nombre[]"" name=""nombre[]"" class=""form-control "" id=""' + i + '"" /> </div><div class=""col-md-1"" id=li' + i + '><label>Eliminar</label><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></div><div class=""col-md-12 text-danger"" id=li' + i + ' hidden>El campo fecha y hora es requerido.</div>');

            i++;
        });
        $(""#CheckBox"").click(function () {
            $('#ul').append('<div class=""col-md-8"" id=li' + i + '><input hidden  asp-for=""tipo[]"" name=""tipo[]""  id=""checkbox' + i + '"" value=""checkbox""/>Nombre del");
            WriteLiteral(@" campo CheckBox: <input type=""text"" required  asp-for=""nombre[]"" name=""nombre[]"" class=""form-control input-mini"" id=' + i + '/></div><div class=""col-md-1"" id=li' + i + '><label>Eliminar</label><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></div>');

            //$(""#ul"").append('<li id=li' + i + '><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></li>');
            i++;
        });
        $(""#TextArea"").click(function () {
            $('#ul').append('<div class=""col-md-8"" id=li' + i + '><input hidden asp-for=""tipo[]"" name=""tipo[]"" id=""textArea' + i + '"" value=""textArea""/>Nombre del Texto Grande: <input required type=""text""  asp-for=""nombre[]"" name=""nombre[]"" class=""form-control input-mini"" id=' + i + '/></div><div class=""col-md-1"" id=li' + i + '><label>Eliminar</label><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></div>');

            //  $(""#ul"").a");
            WriteLiteral(@"ppend('<li id=li' + i + '><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></li>');
            i++;
        });
        $(""#Text"").click(function () {
            $('#ul').append('<div class=""col-md-8"" id=li' + i + '><input hidden asp-for=""tipo[]"" name=""tipo[]"" id=""text' + i + '"" value=""text""/>Nombre del texto: <input type=""text"" required asp-for=""nombre[]"" name=""nombre[]"" class=""form-control input-mini"" id=' + i + '/></div><div class=""col-md-1"" id=li' + i + '><label>Eliminar</label><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></div>');

            // $(""#ul"").append('<li id=li' + i + '><button class=""btn btn-link"" onclick=""eliminar(' + i + ');""><i class=""fas fa-trash""></i></button></li>');
            i++;
        });
    });
    function eliminar(id) {
        var opcion = confirm(""Esta seguro que desea eliminar el campo?"");
        var mensaje;
        if (opcion == true) {
             $.aja");
            WriteLiteral("x({\r\n                headers: {\r\n                    \"RequestVerificationToken\": \'");
            EndContext();
            BeginContext(11950, 25, false);
#line 303 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                                            Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(11975, 80, true);
            WriteLiteral("\'\r\n                },\r\n                type: \"POST\",\r\n\r\n\r\n                url: \'");
            EndContext();
            BeginContext(12056, 44, false);
#line 308 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                 Write(Url.Action("Delete", "CamposPersonalizados"));

#line default
#line hidden
            EndContext();
            BeginContext(12100, 637, true);
            WriteLiteral(@"',

                 data:{id : id},
                 success: function (data) {
                     window.location.reload();
                },

                error: function (err, scnd) {
                    console.log(err.statusText);
                }

            });

        } else {
            return;
        }


    }
</script>


<script>
    //llamar modal con datas para crear campos personalizados.
    $('#CamposPersonalizados').change(function () {

        if ($(this).val() == ""Lista"") {
            $.ajax({
                headers: {
                    ""RequestVerificationToken"": '");
            EndContext();
            BeginContext(12738, 25, false);
#line 337 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                                            Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(12763, 79, true);
            WriteLiteral("\'\r\n                },\r\n                type: \"GET\",\r\n\r\n\r\n                url: \'");
            EndContext();
            BeginContext(12843, 44, false);
#line 342 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                 Write(Url.Action("CrearLista", "ListaDesplegable"));

#line default
#line hidden
            EndContext();
            BeginContext(12887, 1059, true);
            WriteLiteral(@"',


                success: function (data) {
                    $('#crearEditarPartial').empty();
                    $('#crearEditarPartial').html(data);
                    $('#myModal').modal('show');
                },

                error: function (err, scnd) {
                    console.log(err.statusText);
                }

            });
        } else if ($(this).val() == ""fechaHora"") {

            llamarModalCampos(""datetime-local"");
        } else if ($(this).val() == ""checkBox"") {
            llamarModalCampos(""checkbox"");
        } else if ($(this).val() == ""textArea"") {
            llamarModalCampos(""textArea"");
        } else if ($(this).val() == ""text"") {
            llamarModalCampos(""text"");
        }

    });

    function llamarModalCampos(tipo) {

        var domain1 = {
            id:0,
            nombre: """",
            tipo:tipo,
            estado : ""Activo""
        };
         $.ajax({
                    headers: {
                  ");
            WriteLiteral("      \"RequestVerificationToken\": \'");
            EndContext();
            BeginContext(13947, 25, false);
#line 379 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
                                                Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(13972, 85, true);
            WriteLiteral("\'\r\n                    },\r\n                    type: \"POST\",\r\n\r\n\r\n             url: \'");
            EndContext();
            BeginContext(14058, 63, false);
#line 384 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
              Write(Url.Action("CrearCamposPersonalizados", "CamposPersonalizados"));

#line default
#line hidden
            EndContext();
            BeginContext(14121, 387, true);
            WriteLiteral(@"',
             data: { domain2: domain1 },

              success: function (data) {
                  $('#crearCampos').html(data);
                  $('#myModal1').modal('show');
                    },

                    error: function (err, scnd) {
                        console.log(err.statusText);
                    }

                });
    }


</script>
");
            EndContext();
        }
        #pragma warning restore 1998
#line 7 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\CamposPersonalizados\Create.cshtml"
           
    public string GetAntiXsrfRequestToken()
    {
        return Xsrf.GetAndStoreTokens(Context).RequestToken;
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf { get; private set; }
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
