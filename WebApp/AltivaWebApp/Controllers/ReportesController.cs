using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Helpers;
using AltivaWebApp.Services;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    public class ReportesController : Controller
    {

        private readonly IPuntoVentaService pvService;

        public ReportesController( IPuntoVentaService pvService)
        {
  
            this.pvService = pvService;
       
        }
        public IActionResult Ventas()
        {
            ViewData["puntoVenta"] = pvService.GetAll();
            return View();
        }

        
        public ActionResult rtpVentas(string idPuntoV, string fDesde, string fHasta, string nombreCliente, string idVendedor, string estado)
        {
            FastReport.Utils.Config.WebMode = true;
            var rep = new WebReport();
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");//carpeta reportes
            var path = $"{savePath}\\InformeVentasSimple.frx";//guarda el frm del reporte creado de fast repor
            if (fDesde==null) {
                fDesde = "";
            }
            if (fHasta == null)
            {
                fHasta = "";
            }
            if (nombreCliente == null)
            {
                nombreCliente = "";
            }
            if (idVendedor == null)
            {
                idVendedor = "";
            }
            if (estado == null)
            {
                estado = "";
            }
            string titulo = "";
            if (!fDesde.Equals("")) {

                titulo += "Desde: " + fDesde + " Hasta: " + fHasta;
            }
            if (!nombreCliente.Equals(""))
            {

                titulo += " Cliente: " + nombreCliente;
            }
            if (!idVendedor.Equals(""))
            {

                titulo += " Vendedor: " + idVendedor;
            }
            if (!estado.Equals(""))
            {

                titulo += " Estado: " + estado;
            }


            rep.Report.Load(path);

            var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name);// consulta a la clase JsonStringProvider AltivaWebApp/resources/JsonStringProvider si estan creados los archivos de traduccion para los reportes

            rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringGE;// primera conexion

            rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;

            //rep.Report.Dictionary.Connections[2].ConnectionString = str;

            rep.Report.SetParameterValue("TituloParametros", titulo);
            if (fDesde.Equals("")){ fDesde = "01/01/2000";fHasta = "01/01/2000"; }
            rep.Report.SetParameterValue("FDesde", fDesde);
            rep.Report.SetParameterValue("FHasta", fHasta);
            rep.Report.SetParameterValue("NombreCliente", nombreCliente);
            rep.Report.SetParameterValue("IdVendedor", idVendedor);
            rep.Report.SetParameterValue("Estado", estado);

            rep.Report.Prepare();

            ViewBag.reporte = rep;
            return View();
        }

    }
}