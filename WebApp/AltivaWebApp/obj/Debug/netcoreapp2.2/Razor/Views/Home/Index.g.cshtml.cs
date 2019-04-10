#pragma checksum "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a9c55157a756a3d498a182f4f675950293740c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a9c55157a756a3d498a182f4f675950293740c2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"126a05e3a3a8e0538c9347fb29de305015eab212", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "_HomeLayout";


#line default
#line hidden
            BeginContext(76, 294, true);
            WriteLiteral(@"
<div class=""row"">
    <h4 data-translate=""indexGrupoDeEmpresas"">Ir al grupo de empresas</h4>
</div>
<hr />

<div class=""row"">
    <div class=""col-md-12"">
        <h6 data-translate=""indexNombreGrupo"">Digite el nombre del grupo empresarial</h6>
    </div>
    <div class=""col-md-3"">
");
            EndContext();
#line 17 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Home\Index.cshtml"
         if (ViewBag.error != null)
        {

#line default
#line hidden
            BeginContext(418, 66, true);
            WriteLiteral("            <span data-translate=\"indexError\" class=\"text-danger\">");
            EndContext();
            BeginContext(485, 13, false);
#line 19 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Home\Index.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
            EndContext();
            BeginContext(498, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 20 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(518, 1097, true);
            WriteLiteral(@"        <div class=""input-group"">
            <input data-translate=""indexInputNombreGrupo"" required type=""text"" id=""txt_grupo"" class=""form-control"" placeholder=""Nombre del grupo empresarial"">
            <div class=""input-group-append"">
                <button data-translate=""indexBtnIrGE"" id=""ir"" class=""btn btn-outline-primary"">Ir</button>
            </div>
        </div>
    </div>
</div>


<script type=""text/javascript"">

    $(document).ready(function () {

   
     

        $('#ir').attr(""disabled"", true);


        $('#ir').click(function () {
            setUrl();
        });

        

        $('#txt_grupo').keyup(function (e) {
            //console.log($(this).val());
            if($(this).val() === '')
                $('#ir').attr(""disabled"", true);
            else
                $('#ir').attr(""disabled"", false);

            var code = (e.keyCode ? e.keyCode : e.which); if (code == 13) { setUrl(); return false; }
        });


        function setUrl(){");
            WriteLiteral("\r\n            var grupo = $(\'#txt_grupo\').val();\r\n            var url = \'");
            EndContext();
            BeginContext(1616, 47, false);
#line 60 "C:\Users\altiva_juan\Documents\GitHub\altivawebapp\WebApp\AltivaWebApp\Views\Home\Index.cshtml"
                  Write(Url.Action("Login", new { grupo = "__grupo__"}));

#line default
#line hidden
            EndContext();
            BeginContext(1663, 126, true);
            WriteLiteral("\';\r\n\r\n            window.location.href = url.replace(\'__grupo__\', grupo);\r\n        }\r\n        \r\n    });\r\n</script>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
