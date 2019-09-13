using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AltivaWebApp.Helpers;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FastReport.Web;
using System.Globalization;

namespace AltivaWebApp.Controllers
{

    [Route("{culture}/Traslados")]
    public class TrasladoController : Controller
    {

        private readonly ITrasladoService trasladoService;
        private readonly ITrasladoMap trasladoMap;
        private readonly IUserService userService;
        private readonly ITrasladoInventarioService trasladoInventarioService;
        private readonly ITrasladoInventarioMap trasladoInventarioMap;
        private readonly IKardexMap kardexMap;


        //constructor
        public TrasladoController(ITrasladoService _trasladoService, ITrasladoMap _trasladoMap, IUserService _userService, ITrasladoInventarioService _trasladoInventarioService, ITrasladoInventarioMap _trasladoInventarioMap, IKardexMap kardexMap)
        {
            this.trasladoService = _trasladoService;
            this.trasladoMap = _trasladoMap;
            this.userService = _userService;
            this.trasladoInventarioService = _trasladoInventarioService;
            this.trasladoInventarioMap = _trasladoInventarioMap;
            this.kardexMap = kardexMap;
        }

        [Route("Lista-traslados")]
        public ActionResult ListarTraslados()
        {
            return View();
        }

        [HttpGet("Listar-Traslados")]
        public IActionResult _ListarTraslados()
        {
            return PartialView("_ListarTraslados");
        }

        [HttpGet("Crear-Traslado")]
        public IActionResult _CrearTraslado()
        {

            return PartialView("_CrearEditarTraslado", new TrasladoViewModel());
        }

        [HttpGet("Editar-Traslado/{id}")]
        public IActionResult _EditarTraslado(long id)
        {
            return PartialView("_CrearEditarTraslado", trasladoMap.DomainToViewModel(trasladoService.GetTrasladoById(id)));
        }



        [HttpGet("Get-Traslados")]
        public ActionResult GetTraslados()
        {
            try
            {
                var traslado = trasladoService.GetAllTraslado();//revisar obtiene todos los usuarios

                foreach (var item in traslado)
                {
                    item.IdBodegaDestinoNavigation.TbPrTrasladoIdBodegaDestinoNavigation = null;
                    item.IdBodegaOrigenNavigation.TbPrTrasladoIdBodegaOrigenNavigation = null;
                }

                return Ok(traslado);
            }
            catch (Exception ex)
            {   AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }





        [HttpPost("CrearEditar-Traslado")]
        public ActionResult CrearEditarTraslado(TrasladoViewModel traslado, IList<TrasladoInventarioViewModel> inventarioTraslado, IList<long> eliminados)
        {
        
            try
            {

                if (traslado.Comentario == null)
                {
                    traslado.Comentario = "";
                }
                
                if (traslado.IdTraslado != 0)
                {
                   IList<TbPrTrasladoInventario> detallesToAnular = trasladoService.GetAllTrasladoInvetarioDetalleById(inventarioTraslado.Select(d => (long)d.Id).Where(d => d != 0).ToList());//enviar las que vienen sin id y no devuelve nada
                   kardexMap.CreateKardexTRI(detallesToAnular, true); // va y vuelve nadamas si la lineas se editaron, y no son nuevas

               
                    if (inventarioTraslado.Count() > 0)
                    {
                        
                        var trasladoInventarioDetalle = trasladoMap.CreateOrUpdateAI(inventarioTraslado);//envia las que vienen sin id para retornarlas con id, y actualiza en la tabla detalle

                        kardexMap.CreateKardexTRI(trasladoInventarioDetalle, false);

                        var respTraslado = trasladoMap.Update(traslado);//actualiza en la tabla traslado
                                       
                    }


                    if (eliminados.Count() > 0)
                    {

                        var resp = trasladoService.GetAllTrasladoInvetarioDetalleById(eliminados);                     
                        trasladoService.DeleteTrasladoInventario(eliminados);
                        kardexMap.CreateKardexTRI(resp, true);
                    }
                    // kardexMap.CreateKardexTRI(respTraslado.TbPrTrasladoInventario.ToList(), false);




                }
                else
                {
                    traslado.TrasladoInventarioDetalle = inventarioTraslado;
                    traslado.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    traslado.FechaCreacion = DateTime.Now;
                    traslado.Anulado = false;//cambiar luego

                    var respTraslado = trasladoMap.Create(traslado);

                    foreach (var item in inventarioTraslado)
                    {
                        item.IdTraslado = respTraslado.IdTraslado;
                    }
                    respTraslado.TbPrTrasladoInventario = trasladoMap.CreateOrUpdateAI(inventarioTraslado); //envia los item sin id para devolverlos con id

                    kardexMap.CreateKardexTRI(respTraslado.TbPrTrasladoInventario.ToList(), false);

                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }
        }



        [HttpGet("Get-TrasladoInventario/{id}")]
        public ActionResult GetTrasladoInventario(long id)
        {
            try
            {

                var trasladoInventario = trasladoInventarioService.GetTrasladoInventarioById(id);

                return Ok(trasladoInventario);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("Get-Traslado/{id}")]
        public ActionResult GetTraslado(long id)
        {
            try
            {
                var traslado = trasladoService.GetTrasladoById(id);

               
                return Ok(traslado);
            }
            catch
            {
                return BadRequest();
            }
        }

       
        [HttpGet("Anular-Traslado/{id}")]
        public ActionResult AnularTraslado(int id)
        {
            try
            {
                var traslado = trasladoService.GetTrasladoById(id);
                var anulado = traslado.Anulado;

                if (anulado == false)
                {

                    traslado.Anulado = true;
                    trasladoService.Update(traslado);

                    var tras = trasladoService.GetTrasladoWithDetails(id);
                    tras.Anulado = true;
                    kardexMap.CreateKardexTRI(tras.TbPrTrasladoInventario.ToList(), true);


                    var res = true;
                    return Json(new { success = res });




                }
                else
                {
                    var res = false;
                    return Json(new { success = res });
                }

            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpGet("Crear-PDF")]
        public IActionResult _CrearPDF()
        {

                    FastReport.Utils.Config.WebMode = true;
                    var rep = new WebReport();
                    var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");//carpeta reportes
                    var path = $"{savePath}\\ReporteGeneralTraslado.frx";//guarda el frm del reporte creado de fast repor


                    rep.Report.Load(path);

                    var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name);// consulta a la clase JsonStringProvider AltivaWebApp/resources/JsonStringProvider si estan creados los archivos de traduccion para los reportes

                    rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringEmpresas;// primera conexion
                    rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringGE;
                    rep.Report.Dictionary.Connections[3].ConnectionString = str;

                    //  rep.Report.Dictionary.Connections[3].ConnectionString = $"Json=\"{{\"imagen\":\"{HttpContext.Session.GetString("fotoEmpresa")}}}";
                    //  Json = '{"imagen": "https://picsum.photos/200/300"}'; JsonSchema = '{"type":"object","properties":{"imagen":{"type":"string"}}}'; Encoding = utf - 8

                    rep.Report.SetParameterValue("IdEmpresa", HttpContext.Session.GetInt32("idEmpresa"));// envia por parametro el idempresa a fast report

                    rep.Report.Prepare();

                    ViewBag.reporte = rep;


                    return View("_CrearPDF", path);

            

        }


        // POST: AjusteInventario/Delete/5
        [HttpGet("Crear-PDF-Traslado/{id}")]
        public IActionResult CrearPdfEspecifico(int id)
        {


                    FastReport.Utils.Config.WebMode = true;
                    var rep = new WebReport();
                    var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Reportes");//carpeta reportes
                    var path = $"{savePath}\\ReporteEspecificoTraslado.frx";//guarda el frm del reporte creado de fast repor


                    rep.Report.Load(path);

                    var str = Resources.JsonStringProvider.GetJson(CultureInfo.CurrentCulture.Name);// consulta a la clase JsonStringProvider AltivaWebApp/resources/JsonStringProvider si estan creados los archivos de traduccion para los reportes

                    rep.Report.Dictionary.Connections[0].ConnectionString = StringProvider.StringGE;// primera conexion

                    rep.Report.Dictionary.Connections[1].ConnectionString = StringProvider.StringEmpresas;

                    rep.Report.Dictionary.Connections[2].ConnectionString = str;

                    rep.Report.SetParameterValue("IdEmpresa", HttpContext.Session.GetInt32("idEmpresa"));// envia por parametro el idempresa a fast report

                    rep.Report.SetParameterValue("IdTraslado", id);// envia por parametro el idTraslado a fast report

                    rep.Report.Prepare();

                    ViewBag.reporte = rep;




                    return View("_CrearPDF", path);
          
        }










    }
}