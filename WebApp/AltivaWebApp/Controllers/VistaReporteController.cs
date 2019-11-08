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
        public IActionResult ReporteGeneral(string NombreReporte, IList<RepParametro> parametros, bool usaGrupo=true)
        {
            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");//carpeta reportes
            var path = $"{savePath}\\{NombreReporte}.frx";//guarda el frm del reporte creado de fast repor


            rep.Report.Load(path);

            var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name);//  idioma
            if (usaGrupo)
            {
                 rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringGE;
                rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringEmpresas;// primera conexion
                rep.Report.Dictionary.Connections[2].ConnectionString = str;
            }
            else
            {
                // rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringGE;
                rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;// primera conexion
                rep.Report.Dictionary.Connections[1].ConnectionString = str;
            }

            foreach (var item in parametros)
            {
                rep.Report.SetParameterValue(item.Nombre,long.Parse( item.Valor));// envia por parametro el idempresa a fast report
            }

           // rep.ShowToolbar = false;
            //rep.Height = 

            rep.Report.Prepare();

            ViewBag.reporte = rep;

            return PartialView("../Reporte/_Reporte", NombreReporte);

        }

        [HttpPost("ReportePDF")]
        public IActionResult ReportePDF(string NombreReporte, IList<RepParametro> parametros)
        {
            try
            {
                FastReport.Utils.Config.WebMode = true;
                var rep = new WebReport();
                var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
                var path = $"{savePath}\\{NombreReporte}.frx";//guarda el frm del reporte creado de fast repor

                rep.Report.Load(path);

                var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name); //idioma
                rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringGE;
                rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringEmpresas;// primera conexion
                rep.Report.Dictionary.Connections[2].ConnectionString = str;


                foreach (var item in parametros)
                {
                    rep.Report.SetParameterValue(item.Nombre, item.Valor);// envia por parametro el idempresa a fast report
                }


                if (rep.Report.Prepare())
                {
                    FastReport.Export.Pdf.PDFExport imgExport = new FastReport.Export.Pdf.PDFExport();


                    MemoryStream strm = new MemoryStream();
                    rep.Report.Export(imgExport, strm);
                    rep.Report.Dispose();
                    imgExport.Dispose();
                    strm.Position = 0;

                    return File(strm, "application/pdf", $"{NombreReporte}.pdf");
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex) { AltivaLog.Log.Insertar(ex.ToString(), "Error"); return null; }
        }

        [HttpPost("ReporteImg")]
        public IActionResult ReporteImg(string NombreReporte, IList<RepParametro> parametros)
        {

            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
            var path = $"{savePath}\\{NombreReporte}.frx";//guarda el frm del reporte creado de fast repor

            rep.Report.Load(path);

            var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name); //idioma
            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringGE;
            rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringEmpresas;// primera conexion
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
                imgExport.Resolution = 300;


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

        [HttpPost("ReporteHTML")]
        public IActionResult ReporteHTML(string NombreReporte, IList<RepParametro> parametros)
        {

            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");
            var path = $"{savePath}\\{NombreReporte}.frx";//guarda el frm del reporte creado de fast repor

            rep.Report.Load(path);

            var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name); //idioma
            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringGE;
            rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringEmpresas;// primera conexion
            rep.Report.Dictionary.Connections[2].ConnectionString = str;


            foreach (var item in parametros)
            {
                rep.Report.SetParameterValue(item.Nombre, item.Valor);// envia por parametro el idempresa a fast report
            }

            rep.Report.Prepare();


            FastReport.Export.Html.HTMLExport html = new FastReport.Export.Html.HTMLExport();
            html.ShowProgress = false;
            html.SinglePage = true;
            html.Navigator = false; // Top navigation bar
            html.EmbedPictures = true; // Embeds images into a document

            MemoryStream strm = new MemoryStream();
            rep.Report.Export(html, strm);
            rep.Report.Dispose();
            html.Dispose();
            strm.Position = 0;

            var res = Encoding.UTF8.GetString(strm.ToArray()); //File(strm.ToArray(), "text/html", $"{NombreReporte}.html");


            return Ok(res);
            //using (HTMLExport html = new HTMLExport())
            //{
            //    MemoryStream strm = new MemoryStream();
            //    rep.Report.Export(html, strm);
            //    return File(strm, "text/html", $"{NombreReporte}.html");
            //}


        }

        

    }
    public class RepParametro
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }

    }
}
    