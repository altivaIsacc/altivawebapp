#pragma checksum "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Monedas\getTipoCambio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb927f83e34babf2c7023ded0bb6c124312b85d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Monedas_getTipoCambio), @"mvc.1.0.view", @"/Views/Monedas/getTipoCambio.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Monedas/getTipoCambio.cshtml", typeof(AspNetCore.Views_Monedas_getTipoCambio))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb927f83e34babf2c7023ded0bb6c124312b85d5", @"/Views/Monedas/getTipoCambio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"126a05e3a3a8e0538c9347fb29de305015eab212", @"/Views/_ViewImports.cshtml")]
    public class Views_Monedas_getTipoCambio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AltivaWebApp.GEDomain.TbSeMoneda>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(240, 154, true);
            WriteLiteral("\r\n\r\n<script>\r\n    function cambioMoneda(valor) {\r\n          $.ajax({\r\n                headers: {\r\n                           \"RequestVerificationToken\": \'");
            EndContext();
            BeginContext(395, 25, false);
#line 16 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Monedas\getTipoCambio.cshtml"
                                                   Write(GetAntiXsrfRequestToken());

#line default
#line hidden
            EndContext();
            BeginContext(420, 79, true);
            WriteLiteral("\'\r\n                },\r\n                type: \"GET\",\r\n\r\n\r\n                url: \'");
            EndContext();
            BeginContext(500, 37, false);
#line 21 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Monedas\getTipoCambio.cshtml"
                 Write(Url.Action("getTipoCambio","Monedas"));

#line default
#line hidden
            EndContext();
            BeginContext(537, 1022, true);
            WriteLiteral(@"',

                data: { id: valor },

                contentType: ""application/json; charset=utf-8"",
              success: function (data) {

                  $(""#tipoCambioCompra"").text(data.valorCompra);
                  $(""#tipoCambioVenta"").text(data.valorVenta);
                },

                dataType: ""json""

        });





    }
    $(document).ready(function () {




        $(""#moneda"").append(' <select class=""btn btn-primary btn-sm"" id=""tipoMoneda"">< option > Seleccione</option ><option value=""2"" selected=""selected"">Dolar</option><option value=""3"">Euro</option></select> ');

        var valor1 = $(""select#tipoMoneda"").val();

        cambioMoneda(valor1);

        $(""#tipoMoneda"").change(function () {

            var valor = $(this).children(""option:selected"").val();
            if (valor == 'Seleccione') {
                $(""#tipoCambio"").val(0);
            }
            cambioMoneda(valor);


        });



    });



</script>

");
            EndContext();
        }
        #pragma warning restore 1998
#line 4 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Monedas\getTipoCambio.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AltivaWebApp.GEDomain.TbSeMoneda> Html { get; private set; }
    }
}
#pragma warning restore 1591
