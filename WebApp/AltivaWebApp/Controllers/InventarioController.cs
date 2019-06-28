using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Repositories;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Inventario")]
    public class InventarioController : Controller
    {
        readonly IInventarioService service;
        readonly IInventarioMap map;
        readonly IBodegaService bodegaService;
        readonly IUnidadService unidadService;
        readonly IFamiliaService familiaService;
        readonly IFamiliaOnlineService familiaOnlineService;
        readonly IMonedaService monedaService;
        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;
        readonly IHostingEnvironment hostingEnvironment;
        public InventarioController(IStringLocalizer<SharedResources> sharedLocalizer, IHostingEnvironment hostingEnvironment, IMonedaService monedaService, IFamiliaService familiaService,IFamiliaOnlineService familiaOnlineService, IUnidadService unidadService, IBodegaService bodegaService, IInventarioService service, IInventarioMap map)
        {
            this.service = service;
            this.map = map;
            this.bodegaService = bodegaService;
            this.unidadService = unidadService;
            this.familiaService = familiaService;
            this.familiaOnlineService = familiaOnlineService;
            this.monedaService = monedaService;
            this.hostingEnvironment = hostingEnvironment;
        }


        // GET: Inventario
        [Route("Lista-Inventario/{cod?}")]
        public ActionResult ListarInventario(string cod)
        {
            ViewBag.cod = cod;
            ViewData["bodegas"] = bodegaService.GetAllActivas();
            return View();
        }

        [HttpGet("Lista-Inventario/todo")]
        public IActionResult GetAllInventario()
        {
            //ViewData["bodegas"] = bodegaService.GetAllActivas();
            var catalogo = service.GetAllInventario();

            foreach (var item in catalogo)
            {
                item.IdSubFamiliaNavigation.TbPrInventario = null;
                item.IdSubFamiliaNavigation.IdFamiliaNavigation.InverseIdFamiliaNavigation = null;
                item.IdUnidadMedidaNavigation.TbPrInventario = null;
                foreach (var i in item.TbPrInventarioBodega)
                {
                    i.IdBodegaNavigation = null;
                    i.IdInventarioNavigation = null;

                }
            }
            return Ok(catalogo);
        }

        [HttpGet("Equivalencias/{id}")]
        public IActionResult _ListarEquivalencias(int id)
        {
            try
            {
                ViewData["equivalencias"] = service.GetEquivalenciasPorInventario(id);
                var items = service.GetAllInventario();
                ViewData["items"] = items;
                return PartialView(service.GetInventarioById(id));
            }
            catch (Exception)
            {
                return BadRequest();
                //throw;
            }
            
        }

        [HttpGet("Imagenes/{id}")]
        public IActionResult _ListarImagenes(int id)
        {
            try
            {
                return PartialView(service.GetInventarioImagenById(id));
            }
            catch (Exception)
            {
                return BadRequest();
                //throw;
            }
        }


        [HttpGet("Caracteristicas/{id}")]
        public IActionResult _ListarCaracteristicas(int id)
        {
            try
            {
                return PartialView(service.GetInventarioCaracteristicaById(id));
            }
            catch (Exception)
            {
                return BadRequest();
                //throw;
            }

        }


        // GET: Inventario/Create
        [Route("Nuevo-Inventario")]
        public ActionResult CrearInventario()
        {
            var bodegaInventario = new List<TbPrInventarioBodega>();
            ViewData["bodegas"] = bodegaService.GetAllActivas();
            ViewData["bodegaInventario"] = bodegaInventario;
            ViewData["unidades"] = unidadService.GetAll();
            ViewData["moneda"] = monedaService.GetAll();

            ViewBag.accion = "1";

            var model = new InventarioViewModel();

            return View("CrearEditarInventario", model);
        }

        [Route("Editar-Inventario/{id}")]
        public ActionResult EditarInventario(int id)
        {

            if (!ModelState.IsValid)
            {
                var model = new InventarioViewModel();
                return View("CrearEditarInventario", model);
            }
                

            var bodegaInventario = service.GetAllBodegasPorInventario(id);
            ViewData["bodegas"] = bodegaService.GetAllActivas();
            ViewData["bodegaInventario"] = bodegaInventario;
            ViewData["unidades"] = unidadService.GetAll();
            ViewData["moneda"] = monedaService.GetAll();

            var item = map.DomainToViewModel(service.GetInventarioById(id));

            return View("CrearEditarInventario", item);
        }

        // POST: Inventario/Create
        [HttpPost("CrearEditar-Inventario/{id?}")]
        public ActionResult CrearEditarInventario(int id, InventarioViewModel model)
        {
            try
            {
                if (model.DescripcionVenta == null)
                    model.DescripcionVenta = model.Descripcion;
                var inventario = new TbPrInventario();

                var idInventario = 0;
                var codigoInventario = "";

                if(id == 0)
                {
                    inventario = service.GetInventarioByCodigo(model.Codigo);
                    if (inventario == null)
                    {
                        var idUser = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                        model.IdUsuario = int.Parse(idUser);
                        inventario = map.Create(model);
                        idInventario = (int) inventario.IdInventario;
                    }
                }
                else
                {
                    inventario = service.GetInventarioByCodigo(model.Codigo);
                    var flag = true;

                    if (inventario != null)
                        if (inventario.IdInventario != id)
                        {
                            flag = false;
                            idInventario = 0;
                        }
                            
                    if (flag)
                    {
                        inventario = map.Update(id, model);
                        idInventario = id;
                        codigoInventario = inventario.Codigo;
                    }


                    

                }

                return Json(new { id = idInventario, codigo = codigoInventario });
            }
            
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("CrearEditar-InventarioBodega/{id}")]
        public ActionResult CrearInventarioBodega(int id, IList<InventarioBodegaViewModel> inventarioBodega)
        {
            try
            {
                
                map.CreateInventarioBodega(id, inventarioBodega);

                return Json(new { success = true });
            }
            catch
            {
                //throw;
                return BadRequest();
            }
        }

        [HttpPost("Crear-Equivalencia")]
        public IActionResult CrearEquivalencia(TbPrEquivalencia model)
        {
           
            try
            {

                var res = true;
                var existeEquivalencia = service.ExisteEquivalencia(model);

                if (!existeEquivalencia)
                    res = service.SaveEquivalencia(model);


                return Json( new { success = res, existe = existeEquivalencia });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("Eliminar-Equivalencia/{id}")]
        public IActionResult EliminarEquivalencia(int id)
        {

            try
            {
                var res = service.DeleteEquivalencia(id);
                return Json(new { success = res });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("Eliminar-Caracteristica/{id}")]
        public IActionResult EliminarCaracteristica(int id)
        {

            try
            {
                var res = service.DeleteCaracteristica(id);
                return Json(new { success = res });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("Eliminar-Imagen/{id}")]
        public IActionResult EliminarImagen(int id)
        {

            try
            {
                var res = service.DeleteImagen(id);
                return Json(new { success = res });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("CambiarEstado-Inventario/{id}")]
        public ActionResult CambiarEstadoInventario(int id)
        {
            try
            {
                var item = service.GetInventarioById(id);
                if (item.Inactiva)
                    item.Inactiva = false;
                else
                    item.Inactiva = true;

                var res = service.Update(item);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
                //throw;
            }
        }

        [HttpGet("EliminarInventarioBodega/{id}")]
        public ActionResult EliminarInventarioBodega(int id)
        {
            try
            {
                var res = service.EliminarInventarioBodega(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //get auxiliares

        [HttpGet("get-bodegas/{id}")]
        public IActionResult GetBodegas(int id)
        {
            var bodegas = service.GetAllBodegasPorInventario(id);

            foreach (var item in bodegas)
            {
                item.IdBodegaNavigation.TbPrInventarioBodega = null;
            }

            return Ok(bodegas);
        }

        [HttpGet("get-familias")]
        public IActionResult GetFamilia()
        {
            try
            {
                var familias = familiaService.GetAllFamilias();

                foreach (var item in familias)
                {
                    foreach (var i in item.InverseIdFamiliaNavigation)
                    {
                        i.InverseIdFamiliaNavigation = null;
                        i.IdFamiliaNavigation = null;
                    }
                }

                return Ok(familias);
            }
            catch (Exception)
            {
                return BadRequest();
            }  
        }

        public IActionResult GetFamiliaOnline()
        {
            try
            {
                var familias = familiaOnlineService.GetAllFamilias();

                foreach (var item in familias)
                {
                    foreach (var i in item.InverseIdFamiliaNavigation)
                    {
                        i.InverseIdFamiliaNavigation = null;
                        i.IdFamiliaNavigation = null;
                    }
                }

                return Ok(familias);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        
        [HttpPost("CargarImagenesInventario/{id}")]
        public ActionResult CargarImagenesInventario(int id, IFormFile[] files)
        {
            try
            {
                map.CreateImagen(id, files);
                

            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("EditarInventario", new { id });
        }

        [HttpPost("CargarCaracteristicasInventario/{id}")]
        public ActionResult CargarCaracteristicasInventario(int id, string model)
        {
            try
            {
                map.CreateCaracteristica(id, model);


            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("EditarInventario", new { id });
        }


    }
}