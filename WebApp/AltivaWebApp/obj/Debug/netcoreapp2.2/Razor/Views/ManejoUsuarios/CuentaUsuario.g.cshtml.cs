#pragma checksum "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81ad0d1ffc472c0aa9bb49ccd31061f0e61a9040"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManejoUsuarios_CuentaUsuario), @"mvc.1.0.view", @"/Views/ManejoUsuarios/CuentaUsuario.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManejoUsuarios/CuentaUsuario.cshtml", typeof(AspNetCore.Views_ManejoUsuarios_CuentaUsuario))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ad0d1ffc472c0aa9bb49ccd31061f0e61a9040", @"/Views/ManejoUsuarios/CuentaUsuario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"126a05e3a3a8e0538c9347fb29de305015eab212", @"/Views/_ViewImports.cshtml")]
    public class Views_ManejoUsuarios_CuentaUsuario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AltivaWebApp.GEDomain.TbSeUsuario>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CrearComentarioUsuario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Mensajes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:auto;  font-size:1.1em;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
  
    var ids = @ViewBag.id;

#line default
#line hidden
            BeginContext(274, 355, true);
            WriteLiteral(@"
<style>
    .btn-circle {
        width: 20px;
        height: 20px;
        text-align: center;
        padding: 4px 0;
        font-size: 8px;
        line-height: 1.428571429;
        border-radius: 10px;
    }

    .btn-combined {
        background-image: linear-gradient(to right, black, white);
    }
</style>

<div class=""row"">
");
            EndContext();
#line 30 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
     if (Model.Codigo == User.Identity.Name)
    {

#line default
#line hidden
            BeginContext(682, 63, true);
            WriteLiteral("        <h3 data-translate=\"layoutNAVMicuenta\">Mi Cuenta</h3>\r\n");
            EndContext();
#line 33 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(769, 66, true);
            WriteLiteral("        <h3 data-translate=\"MUCuentaUsuario\">Cuenta Usuario</h3>\r\n");
            EndContext();
#line 37 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
    }

#line default
#line hidden
            BeginContext(842, 187, true);
            WriteLiteral("\r\n    <a class=\"btn btn-link btnAtras\" data-translate=\"atras\">Atrás</a>\r\n\r\n    <hr />\r\n    <div class=\"col-md-2\">\r\n        <h4>Avatar</h4>\r\n        <img style=\"height: 15rem; width:15rem\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1029, "\"", 1048, 1);
#line 44 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
WriteAttributeValue("", 1035, Model.Avatar, 1035, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1049, 231, true);
            WriteLiteral(" class=\"img-circle\" />\r\n\r\n        <div class=\"row\">\r\n            <a data-translate=\"avatar\" class=\"btn btn-link\" data-toggle=\"modal\" data-target=\"#exampleModal\">\r\n                Cargar tu avatar\r\n            </a>\r\n        </div>\r\n");
            EndContext();
#line 51 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
         if (Model.Codigo == User.Identity.Name)
        {

#line default
#line hidden
            BeginContext(1341, 1131, true);
            WriteLiteral(@"            <div class=""row"">
                <h5 data-translate=""tema"">Tema: </h5>

                <div class=""col-md-12"">
                    <span data-translate=""MUFuenteM"">Fuente M:</span>
                    <button type=""button"" name=""1"" value=""TemaClaro"" class=""btn btntema btn-default btn-circle""></button>
                    <button type=""button"" name=""2"" value=""TemaOscuro"" class=""btn btntema btn-dark btn-circle""></button>
                    <button type=""button"" name=""3"" value=""TemaCombinado"" class=""btn btntema btn-combined btn-circle""></button>
                </div>

                <div class=""col-md-12"">
                    <span data-translate=""MUFuenteG"">Fuente G:</span>
                    <button type=""button"" name=""4"" value=""TemaClaroG"" class=""btn btntema btn-default btn-circle""></button>
                    <button type=""button"" name=""5"" value=""TemaOscuroG"" class=""btn btntema btn-dark btn-circle""></button>
                    <button type=""button"" name=""6"" value=""TemaCombin");
            WriteLiteral("adoG\" class=\"btn btntema btn-combined btn-circle\"></button>\r\n                </div>\r\n\r\n            </div>\r\n");
            EndContext();
#line 71 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
        }

#line default
#line hidden
            BeginContext(2483, 273, true);
            WriteLiteral(@"
    </div>


    <div class=""col-md-6"">
        <h4 data-translate=""MUDatosUsuario"">Datos de usuario</h4>
        <table class=""table table-bordered"">

            <tbody>
                <tr>
                    <th scope=""Row"">Id</th>
                    <td>");
            EndContext();
            BeginContext(2757, 34, false);
#line 83 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                   Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(2791, 150, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th data-translate=\"codigo\" scope=\"row\">Codigo</th>\r\n                    <td> ");
            EndContext();
            BeginContext(2942, 38, false);
#line 87 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                    Write(Html.DisplayFor(model => model.Codigo));

#line default
#line hidden
            EndContext();
            BeginContext(2980, 149, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th data-translate=\"nombre\" scope=\"row\">Nombre</th>\r\n                    <td>");
            EndContext();
            BeginContext(3130, 38, false);
#line 91 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                   Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(3168, 149, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th data-translate=\"estado\" scope=\"row\">Estado</th>\r\n                    <td>");
            EndContext();
            BeginContext(3318, 38, false);
#line 95 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                   Write(Html.DisplayFor(model => model.Estado));

#line default
#line hidden
            EndContext();
            BeginContext(3356, 155, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th data-translate=\"iniciales\" scope=\"row\">Iniciales</th>\r\n                    <td>");
            EndContext();
            BeginContext(3512, 41, false);
#line 99 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                   Write(Html.DisplayFor(model => model.Iniciales));

#line default
#line hidden
            EndContext();
            BeginContext(3553, 348, true);
            WriteLiteral(@"</td>
                </tr>
                <tr>
                    <th data-translate=""contrasena"" scope=""row"">Contrase&ntildea</th>
                    <td>********</td>
                </tr>
                <tr>
                    <th data-translate=""ultimamod"" scope=""row"">&uacuteltima Modificaci&oacuten</th>
                    <td>");
            EndContext();
            BeginContext(3902, 40, false);
#line 107 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                   Write(Html.DisplayFor(model => model.FechaMod));

#line default
#line hidden
            EndContext();
            BeginContext(3942, 149, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th data-translate=\"correo\" scope=\"row\">Correo</th>\r\n                    <td>");
            EndContext();
            BeginContext(4092, 38, false);
#line 111 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                   Write(Html.DisplayFor(model => model.Correo));

#line default
#line hidden
            EndContext();
            BeginContext(4130, 172, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th data-translate=\"accion\" scope=\"row\">Accion</th>\r\n                    <td><a class=\"btn btn-link\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4302, "\"", 4378, 1);
#line 115 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
WriteAttributeValue("", 4309, Url.Action("EditarUsuario", "ManejoUsuarios", new { id = Model.Id }), 4309, 69, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4379, 246, true);
            WriteLiteral("><span data-translate=\"editar\">Editar</span>&nbsp;<span style=\"font-size: 2rem\"><i class=\"fas fa-edit\"></i></span></a></td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n\r\n\r\n\r\n\r\n    </div>\r\n\r\n    <div class=\"col-md-4\">\r\n        ");
            EndContext();
            BeginContext(4625, 189, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81ad0d1ffc472c0aa9bb49ccd31061f0e61a904014916", async() => {
                BeginContext(4778, 32, true);
                WriteLiteral(" <i class=\"fas fa-comments\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 126 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                                                 WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4814, 516, true);
            WriteLiteral(@"
    </div>


    <div class=""col-md-4"">
        <h4 data-translate=""MUPerfilesAsig"">Perfiles Asignados</h4>
        <table class=""table table-bordered"" id=""perfiles"">
            <thead>
                <tr>
                    <th>
                        <p data-translate=""perfil"">Perfil</p>
                    </th>
                    <th>
                        <p data-translate=""accion"">Acción</p>
                    </th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 144 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                 foreach (var item in @ViewData["Asignados"] as IEnumerable<AltivaWebApp.GEDomain.TbSePerfil>)
                {

#line default
#line hidden
            BeginContext(5461, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5546, 41, false);
#line 148 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(5587, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5679, 101, false);
#line 151 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                       Write(Html.ActionLink("Quitar", "QuitarPerfil", "ManejoUsuarios", new { usuario = Model.Id, id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(5780, 62, true);
            WriteLiteral("\r\n                        </td>\r\n\r\n                    </tr>\r\n");
            EndContext();
#line 155 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"

                }

#line default
#line hidden
            BeginContext(5863, 1657, true);
            WriteLiteral(@"                <tr>
                    <td>
                        <a class=""btn btn-link"" data-toggle=""modal"" data-target=""#perfilModal"">
                            <span style=""font-size:3rem""><i class=""fas fa-plus-circle""></i></span>
                        </a>
                    </td>
                    <td></td>
                </tr>
            </tbody>
        </table>

    </div>

    <div id=""errorDiv"" class=""col-md-6 col-sm-12 alert alert-warning alert-dismissible fade show"" role=""alert"">
        <strong>Lo siento!</strong> <span>Algo ha salido mal, no se pudo guardar la configuración</span>
        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
        </button>
    </div>

</div>


<!-- Modal for perfil-->
<div class=""modal fade"" id=""perfilModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""perfilModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <d");
            WriteLiteral(@"iv class=""modal-content"">
            <div class=""modal-header row"">
                <div class=""col-md-6"">
                    <h4 data-translate=""MUAsignarPerfil"" class=""modal-title"" id=""perfilModalLabel"">Asignar Perfil</h4>
                </div>
                <div class=""col-md-6"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
            </div>
            <div class=""modal-body"" style=""padding-left: 5rem"">
                <div class=""row"">
");
            EndContext();
#line 196 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                     foreach (var item in @ViewData["SinAsignar"] as IEnumerable<AltivaWebApp.GEDomain.TbSePerfil>)
                    {

#line default
#line hidden
            BeginContext(7660, 151, true);
            WriteLiteral("                        <div class=\"col-md-4\" style=\"margin-top: 1rem;\">\r\n\r\n                            <label>\r\n                                <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 7811, "\"", 7827, 1);
#line 201 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
WriteAttributeValue("", 7819, item.Id, 7819, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7828, 16, true);
            WriteLiteral(" class=\"asignar\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 7844, "\"", 7860, 1);
#line 201 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
WriteAttributeValue("", 7851, Model.Id, 7851, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7861, 72, true);
            WriteLiteral(" type=\"checkbox\" data-toggle=\"toggle\">\r\n                                ");
            EndContext();
            BeginContext(7934, 11, false);
#line 202 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                           Write(item.Nombre);

#line default
#line hidden
            EndContext();
            BeginContext(7945, 74, true);
            WriteLiteral("\r\n                            </label>\r\n\r\n                        </div>\r\n");
            EndContext();
#line 206 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"

                    }

#line default
#line hidden
            BeginContext(8044, 1169, true);
            WriteLiteral(@"                </div>
            </div>
            <div class=""modal-footer"">
                <button data-translate=""cancelar"" type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cancelar</button>
                <button data-translate=""guardar"" type=""button"" id=""guardar"" class=""btn btn-primary"">Guardar</button>
            </div>
        </div>
    </div>
</div>
<!-- Modal for avatar-->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""row modal-header"">
                <div class=""col-md-6""><h4 data-translate=""avatar"" class=""modal-title"" id=""exampleModalLabel"">Cargar mi Avatar</h4></div>
                <div class=""col-md-6"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
             ");
            WriteLiteral("       </button>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"modal-body\" style=\"padding-left: 5rem\">\r\n                ");
            EndContext();
            BeginContext(9214, 44, false);
#line 231 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
           Write(await Component.InvokeAsync("Avatar", Model));

#line default
#line hidden
            EndContext();
            BeginContext(9258, 214, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div id=\"comentarios\">\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n<script type=\"text/javascript\">\r\n\r\n\r\n\r\n    $(document).ready(function () {\r\n\r\n        GetComentarios(\'Usuario\', ");
            EndContext();
            BeginContext(9473, 8, false);
#line 250 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                             Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(9481, 324, true);
            WriteLiteral(@");

        $('.btntema').on('click', function () {
            $(""#tema"").attr('href', '/../css/' + $(this).val() + '.css');
            localStorage.setItem('tema', $(this).val());


            var tema = $(this).attr('name');

            /////ajax para guradar el tema en la bd//////
            var userId = ");
            EndContext();
            BeginContext(9806, 8, false);
#line 260 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                    Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(9814, 326, true);
            WriteLiteral(@";

            var config = {
                idUsuario: userId,
                tema: localStorage.getItem('tema'),
                idioma: localStorage.getItem('idioma')
            };

            $.ajax({
                type: ""POST"",
                headers: {
                    ""RequestVerificationToken"": '");
            EndContext();
            BeginContext(10141, 25, false);
#line 271 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                                            Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(10166, 45, true);
            WriteLiteral("\'\r\n                },\r\n                url: \'");
            EndContext();
            BeginContext(10212, 45, false);
#line 273 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                 Write(Url.Action("CambiarConfig", "ManejoUsuarios"));

#line default
#line hidden
            EndContext();
            BeginContext(10257, 449, true);
            WriteLiteral(@"',
                data: config,
                success: function (data) {
                    console.log(data.data);

                },
                    error: function (err, scnd) {
                        console.log(err.statusText);
                        $('#errorDiv').attr('hidden', false);
                }
            });

        });


                    ///al cambiar avatar se cambia en el layout

        if (""");
            EndContext();
            BeginContext(10707, 18, false);
#line 290 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
        Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(10725, 7, true);
            WriteLiteral("\" === \"");
            EndContext();
            BeginContext(10733, 12, false);
#line 290 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                                  Write(Model.Codigo);

#line default
#line hidden
            EndContext();
            BeginContext(10745, 51, true);
            WriteLiteral("\" ) {\r\n            localStorage.setItem(\"avatar\", \"");
            EndContext();
            BeginContext(10797, 12, false);
#line 291 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                                       Write(Model.Avatar);

#line default
#line hidden
            EndContext();
            BeginContext(10809, 980, true);
            WriteLiteral(@""");
            $(""#perfilNAVAvatar"").attr('src', localStorage.getItem(""avatar""));
            $(""#perfilAvatar"").attr('src', localStorage.getItem(""avatar""));
        }


        //metodo para asignar perfiles al usuario

        var arrayModel = [];


        $("".asignar"").change(function () {

            if ($(this).is("":checked"")) {
                var model = {
                    idPerfil: $(this).val(),
                    idUsuario: $(this).attr(""name"")
                };
                arrayModel.push(model);
            }
            else {

                var model = {
                    idPerfil: $(this).val(),
                    idUsuario: $(this).attr(""name"")
                };

                arrayModel.splice($.inArray(model, arrayModel), 1);
            }
            console.log(arrayModel);
        });



        $('#guardar').click(function () {
            console.log(arrayModel);

            var url = '");
            EndContext();
            BeginContext(11790, 45, false);
#line 328 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                  Write(Url.Action("AsignarPerfil", "ManejoUsuarios"));

#line default
#line hidden
            EndContext();
            BeginContext(11835, 136, true);
            WriteLiteral("\';\r\n\r\n            $.ajax({\r\n                type: \"POST\",\r\n                headers: {\r\n                    \"RequestVerificationToken\": \'");
            EndContext();
            BeginContext(11972, 25, false);
#line 333 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
                                            Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(11997, 475, true);
            WriteLiteral(@"'
                },
                url: url,
                data: {model: arrayModel },
                    success: function (data) {
                        //console.log($(this).parent());
                        window.location.href = window.location.href;
                },
                    error: function (err, scnd) {
                        console.log(err.statusText);
                }
            });
        });
    });
</script>





");
            EndContext();
        }
        #pragma warning restore 1998
#line 6 "C:\Users\Trabajo\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\ManejoUsuarios\CuentaUsuario.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AltivaWebApp.GEDomain.TbSeUsuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
