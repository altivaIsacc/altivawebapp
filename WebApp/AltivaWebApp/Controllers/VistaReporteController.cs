using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltivaWebApp.Helpers;
using FastReport;
using FastReport.Export.Html;
using FastReport.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Reportes")]
    public class VistaReporteController : Controller
    {
        [HttpPost("ReporteGeneral")]
        public IActionResult ReporteGeneral(string NombreReporte, IList<RepParametro> parametros)
        {
            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");//carpeta reportes
            var path = $"{savePath}\\{NombreReporte}.frx";//guarda el frm del reporte creado de fast repor


            rep.Report.Load(path);

            var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name);//  idioma

            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;// primera conexion
            rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringGE;
            rep.Report.Dictionary.Connections[2].ConnectionString = str;

            foreach (var item in parametros)
            {
                rep.Report.SetParameterValue(item.Nombre, item.Valor);// envia por parametro el idempresa a fast report
            }

            rep.ShowToolbar = false;

            rep.Report.Prepare();

            ViewBag.reporte = rep;

            return PartialView("../Reporte/_Reporte");

        }

        [HttpGet("ReportePDF")]
        public IActionResult ReportePDF(string NombreReporte, IList<RepParametro> parametros)
        {

            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
            var path = $"{savePath}\\{NombreReporte}.frx";//guarda el frm del reporte creado de fast repor

            rep.Report.Load(path);

            var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name); //idioma
            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;
            rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringGE;
            rep.Report.Dictionary.Connections[2].ConnectionString = str;


            foreach (var item in parametros)
            {
                rep.Report.SetParameterValue(item.Nombre, item.Valor);// envia por parametro el idempresa a fast report
            }


            if (rep.Report.Prepare())
            {
                FastReport.Export.Image.ImageExport imgExport = new FastReport.Export.Image.ImageExport();
                //imgExport.ShowProgress = false;
                imgExport.ImageFormat = FastReport.Export.Image.ImageExportFormat.Jpeg;
                imgExport.SeparateFiles = false;
                imgExport.Resolution = 100;


                MemoryStream strm = new MemoryStream();
                rep.Report.Export(imgExport, strm);
                rep.Report.Dispose();
                imgExport.Dispose();
                strm.Position = 0;

                return File(strm, "image/jpeg", $"{NombreReporte}.pdf");
            }
            else
            {
                return null;
            }


        }

        [HttpGet("ReporteHTML")]
        public IActionResult ReporteHTML(string NombreReporte, IList<RepParametro> parametros)
        {

            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
            var path = $"{savePath}\\{NombreReporte}.frx";//guarda el frm del reporte creado de fast repor

            rep.Report.Load(path);

            var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name); //idioma
            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;
            rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringGE;
            rep.Report.Dictionary.Connections[2].ConnectionString = str;


            foreach (var item in parametros)
            {
                rep.Report.SetParameterValue(item.Nombre, item.Valor);// envia por parametro el idempresa a fast report
            }


            if (rep.Report.Prepare())
            {
                FastReport.Export.Html.HTMLExport html = new FastReport.Export.Html.HTMLExport();
                html.ShowProgress = false;
                html.SinglePage = true;


                MemoryStream strm = new MemoryStream();
                rep.Report.Export(html, strm);
                rep.Report.Dispose();
                html.Dispose();
                strm.Position = 0;

                return File(strm, "text/html", $"{NombreReporte}.html");
            }
            else
            {
                return null;
            }

        }

        

    }
    public class RepParametro
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }

    }
}
    