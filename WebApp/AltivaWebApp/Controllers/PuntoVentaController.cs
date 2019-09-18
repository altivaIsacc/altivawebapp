using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AltivaWebApp.Controllers
{
    [Route("{culture}/PuntoVenta")]
    public class PuntoVentaController : Controller
    {
        private readonly IPuntoVentaService service;
        private readonly IPuntoVentaMap map;
        private readonly IMonedaService monedaService;
        private readonly IContactoService contactoService;
        private readonly IBodegaService bodegaService;
        private readonly IPreciosService precioService;
        public PuntoVentaController(IPreciosService precioService, IPuntoVentaService service, IPuntoVentaMap map, IMonedaService monedaService, IContactoService contactoService, IBodegaService bodegaService)
        {
            this.service = service;
            this.map = map;
            this.monedaService = monedaService;
            this.contactoService = contactoService;
            this.bodegaService = bodegaService;
            this.precioService = precioService;
        

        }
        [Route("PuntoVenta/")]
        public IActionResult ListarPuntosVentas()
        {
            return View();
        }
        [HttpGet("Get-PuntoVenta")]
        public IActionResult GetPuntosVentas()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }
        [HttpGet("Crear-PuntoVenta")]
        public IActionResult CrearPuntoVenta()
        {
            ViewData["tipoPrecios"] = precioService.GetPreciosSinAnular(); 
            ViewData["moneda"] = monedaService.GetAll();
            ViewData["cliente"] = contactoService.GetAllClientes();
            ViewData["bodega"] = bodegaService.GetAllActivas();
            ViewBag.tipoPrecio = new TbPrPrecios();
            return View("CrearEditarPuntoVenta", new PuntoVentaViewModel());
        }
        [HttpGet("Editar-PuntoVenta/{id}")]
        public IActionResult EditarPuntoVenta(int id)
        {
            ViewData["tipoPrecios"] = precioService.GetPreciosSinAnular();
            ViewData["moneda"] = monedaService.GetAll();
            ViewData["cliente"] = contactoService.GetAllClientes();
            ViewData["bodega"] = bodegaService.GetAllActivas();

            var model = service.GetPuntoVentaById(id);

            ViewBag.tipoPrecio = model.IdTipoPrecioDefectoNavigation;
            return View("CrearEditarPuntoVenta",map.DomainToVIewModel(model));
        }
        [HttpPost("CrearEditar-PuntoVenta")]
        public IActionResult CrearEditarPuntoVenta(PuntoVentaViewModel viewModel)
        {
            try
            {
                if (viewModel.Imagen == null)
                     viewModel.Imagen = " ";

                if(!viewModel.TieneConcecutivoIndependiente)
                {
                    viewModel.PrefijoConcecutivoIndepediente = "";
                    viewModel.InicioConcecutivoIndependiente = 0;
                }
                if (!viewModel.TieneEncabezadoIndependiente)
                {
                    viewModel.RazonSocial = "";
                    viewModel.CedulaJuridica= "";
                    viewModel.Email ="";
                    viewModel.Telefono= "";
                    viewModel.Web = "";
                    viewModel.Imagen= "";
                   
                }
                var existe = service.GetPuntoVentaById((int)viewModel.IdPuntoVenta);
                var puntoVenta = new TbSePuntoVenta();
                if (viewModel.IdPuntoVenta != 0)
                {
                    if (existe.IdPuntoVenta == viewModel.IdPuntoVenta)
                    {
                        puntoVenta = map.Update(viewModel);
                    }
                    else
                        return Json(new { success = false });
                }
                else
                {
                    if (existe== null)
                    {
                        viewModel.IdUsuarioCreacion = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                        puntoVenta = map.Create(viewModel);
                      

                    }
                    else
                        return Json(new { success = false });
                }



                return Json(new { success = true, id = puntoVenta.IdPuntoVenta });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }



        }
        [HttpPost("GuardarImagen/{idPuntoVenta}")]
        public IActionResult GuardarImagen(int idPuntoVenta, IFormFile foto)
        {
            try
            {
                var puntoVenta = service.GetPuntoVentaById(idPuntoVenta);
                var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "uploads");
                puntoVenta.Imagen = FotosService.SubirImagenPuntoVenta(foto, savePath);

                service.Update(puntoVenta);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }

        [HttpPost("GetEstadoCajasPuntoVenta")]
        public IActionResult GetEstadoCajasPuntoVenta(long idPV, long idUsuario)
        {
            try
            {
                return Ok(service.GetEstadoCajasPV(idPV, idUsuario));
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
                throw;
            }
        }
    }
}
