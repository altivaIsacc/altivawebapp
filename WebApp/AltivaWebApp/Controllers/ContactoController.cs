using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
using AltivaWebApp.Mappers;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using System.Security.Claims;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Contactos")]
    public class ContactoController : Controller
    {

        private readonly IContactoService contactoService;
        private readonly IContactoMap contactoMap;
        private readonly IContactoCamposMap ccMap;
        private readonly IEstadoTareaService estadoTareaService;
        private readonly ITipoTareaService tipoTareaService;
        private readonly IUserService userService;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IContactoCamposService ccService;
        private readonly IPaisService paisService;
        private readonly ICamposPersonalizadosService cpService;

        public ContactoController(ICamposPersonalizadosService cpService, IPaisService paisService, IUserService IUserService, IHostingEnvironment hostingEnvironment, ITipoTareaService ITipoService, IEstadoTareaService IEstadoService, IContactoCamposService ICCService, IContactoService contactoService, IContactoMap contactoMap, IContactoCamposMap pContactoCamposMap)
        {
            this.contactoService = contactoService;
            this.contactoMap = contactoMap;
            ccMap = pContactoCamposMap;
            this.ccService = ICCService;
            this.userService = IUserService;
            this.hostingEnvironment = hostingEnvironment;
            this.tipoTareaService = ITipoService;
            this.estadoTareaService = IEstadoService;
            this.paisService = paisService;
            this.cpService = cpService;

        }

       
        /// /////////////////////////////////////////////////listar contactos
        
        [HttpGet("Todo")]
        public IActionResult ListarContactos()
        {
            return View();
        }

        [HttpGet("GetAllContactos")]
        public IActionResult GetAllContactos()
        {
            try
            {
                return Ok(contactoService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        /// //////////////////////////////////////////////////////////////////////////crear o editar contacto
        /// 

        [HttpGet("Nuevo")]
        public IActionResult CrearContacto()
        {

            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["paises"] = paisService.GetAll();
            //var camposP = cpService.GetAll(7);
            //ViewData["camposP"] = camposP;

            var contacto = new ContactoViewModel();
            contacto.TipoCedula = "1";

            return View("CrearEditarContacto", contacto);
        }

        [HttpGet("Editar/{id}")]
        public IActionResult EditarContacto(int id)
        {

            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["paises"] = paisService.GetAll();
            var contacto = contactoService.GetByIdContacto(id);


            return View("CrearEditarContacto", contacto);
        }

        [HttpPost("CrearEditarContacto")]
        public IActionResult CrearEditarContacto(IList<CCPersonalizadosViewModel> cpViewModel, ContactoViewModel cViewModel)
        {
            try
            {
                var existeContacto = contactoService.GetByCedulaContacto(cViewModel.Cedula);
                var nuevoContacto = new TbCrContacto();
                if (cViewModel.IdContacto != 0)
                {
                    if (existeContacto != null && existeContacto.IdContacto != cViewModel.IdContacto)
                    {
                        return Json(new { success = false });
                    }

                    nuevoContacto = contactoMap.UpdateContacto(cViewModel);
                    ccMap.Create(cpViewModel, cViewModel.IdContacto);

                    return Json(new { success = true, accion = false, nombre = (bool)nuevoContacto.Persona ? nuevoContacto.Nombre + " " + nuevoContacto.Apellidos : nuevoContacto.NombreComercial });

                }
                else
                {
                    if (existeContacto != null)
                    {
                        return Json(new { success = false });
                    }

                    nuevoContacto = contactoMap.CreateContacto(cViewModel);
                    ccMap.Update(cpViewModel, cViewModel.IdContacto);

                    return Json(new { success = true, accion = false, id = nuevoContacto.IdContacto });


                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("CamposPersonalizados/{idContacto?}")]
        public IActionResult GetCamposPersonalizados(int idContacto)
        {
            try
            {
                var campos = cpService.GetAll(idContacto);
                return Json(campos);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }


        //metodo que devuele en el edit las condiciones de pago.
        [HttpGet("GetCondicionesPago/{idContacto?}")]
        public IActionResult GetCondicionesPago(int idContacto)
        {
            IList<TbFdCondicionesDePago> condiciones = new List<TbFdCondicionesDePago>();
            condiciones = this.contactoService.GetCondiciones(idContacto);
            if (condiciones.Count() > 0)
            {
                return Ok(condiciones);
            }
            else
            {
                return new JsonResult(false);
            }

        }
        //metodo que devuelve los cuentas de un contacto

        [HttpGet("GetCuentasByContacto/{idContacto?}")]
        public IActionResult GetCuentasByContacto(int idContacto)
        {
            var cb = contactoService.GetByContacto(idContacto);
            if (cb.Count() > 0)
            {
                return Ok(cb);
            }
            else
            {
                return Ok(false);
            }

        }

        [HttpGet("RelacionContacto/{idContacto}")]
        public IActionResult _RelacionContacto(int idContacto)
        {
            var contactos = contactoService.GetContactoRelacion(idContacto);
            return PartialView("_RelacionContacto", contactos);
        }

        [HttpPost("EliminarRelacionContacto")]
        public IActionResult EliminarRelacionContacto(int idRelacion)
        {
            try
            {
                contactoService.EliminarRelacion(idRelacion);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        //metodo para agregar condiciones de pago
        [HttpPost("AddCondicionesPago")]
        public IActionResult AddCondicionesPago(TbFdCondicionesDePago domain)
        {
            TbFdCondicionesDePago condicionesPago = new TbFdCondicionesDePago();
            condicionesPago = this.contactoService.AgregarCondicion(domain);


            return new JsonResult(true);
        }
        [HttpPost("EditCondicionesPago")]
        public IActionResult EditCondicionesPago(TbFdCondicionesDePago domain)
        {
            TbFdCondicionesDePago condicionesPago = new TbFdCondicionesDePago();
            condicionesPago = this.contactoService.EditarCondicion(domain);

            return new JsonResult(true);
        }
        [HttpPost("AgregarCuentasBancarias")]
        public IActionResult AgregarCuentasBancarias(TbFdCuentasBancarias domain)
        {

            TbFdCuentasBancarias cb = new TbFdCuentasBancarias();
            cb = this.contactoService.AgregarCuentasBancarias(domain);

            return new JsonResult(true);
        }
        [HttpPost("EditarCuentasBancarias")]
        public IActionResult EditarCuentasBancarias(TbFdCuentasBancarias domain)
        {
            TbFdCuentasBancarias cb = new TbFdCuentasBancarias();
            cb = this.contactoService.EditarCuentas(domain);
            return new JsonResult(true);
        }
        [HttpDelete("DeleteCuentasBancarias/{idCuenta?}")]
        public IActionResult DeleteCuentasBancarias(int idCuenta)
        {
            TbFdCuentasBancarias tc = new TbFdCuentasBancarias();
            tc = this.contactoService.GetCuentasById(idCuenta);
            this.contactoService.DeleteCuentasBancarias(tc);
            return new JsonResult(true);

        }
        [HttpGet]
        public IActionResult PartialCrearTipoCuentaBancaria()
        {
            TbFdCuentasBancarias tc = new TbFdCuentasBancarias();

            return PartialView("_AgregarEditarCuentasBancarias", tc);

        }
        [HttpGet("PartialEditarTipoCuentaBancaria/{idCuenta?}")]
        public IActionResult PartialEditarTipoCuentaBancaria(int idCuenta)
        {
            TbFdCuentasBancarias tc = new TbFdCuentasBancarias();
            tc = this.contactoService.GetCuentasById(idCuenta);
            return PartialView("_AgregarEditarCuentasBancarias", tc);

        }
        

        
        [HttpGet("camposEdit/{id?}")]
        public IActionResult CamposEdit(int id)
        {

            IList<ContactoViewModel> con = new List<ContactoViewModel>();
            con = this.ccService.GetCamposEdit(id);
            return Ok(con);
        }
        [HttpGet("GetContactosRelacion/{id?}")]
        public IActionResult GetContactosRelacion(int id)
        {
            try
            {
                return Ok(contactoService.GetContactoRelacion(id));
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
        


        //metodo que va permitir guardar las relaciones 
        [HttpPost("CrearEditarRelacionC")]
        public IActionResult CrearEditarRelacion(ContactoRelacionViewModel viewModel)
        {
            try
            {
                if(viewModel.Id != 0)
                {
                    var cr = contactoMap.UpdateRelacion(viewModel);
                }
                else
                {
                    var cr = this.contactoMap.CreateRelacion(viewModel);
                }
                
            }
            catch
            {
                return BadRequest();
                throw;
            }
            return new JsonResult(1);
        }


        [HttpGet("_SubContacto")]
        public IActionResult Partial()
        {
            ContactoViewModel con = new ContactoViewModel();

            return PartialView("_SubContacto.cshtml", new ContactoViewModel());
        }

        [HttpGet("GetTareas/{idContacto?}")]
        public IActionResult GetTareas(int idContacto)
        {

            var ccT = this.contactoService.GetTareas(idContacto);
            IList<TbFdTarea> tarea = new List<TbFdTarea>();
            if (ccT.TbFdTarea.Count() > 0)
            {
                foreach (var item in ccT.TbFdTarea)
                {
                    item.IdContactoNavigation = null;
                    item.IdEstadoNavigation.TbFdTarea = null;
                    item.IdTipoNavigation.TbFdTarea = null;
                    tarea.Add(item);
                }
                return Ok(tarea);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("GetProveedores")]
        public IActionResult GetProveedores(int idContacto)
        {
            try
            {
                var prov = contactoService.GetAllProveedores().OrderBy(p => p.Nombre ?? p.NombreJuridico);
                return Ok(prov);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        //////////////////////////////////////localizaciones///////////////////////////////////////

        [HttpPost("Provincias")]
        public IActionResult Provincias()
        {
            IList<TbCeProvincias> provincias = new List<TbCeProvincias>();
            provincias = this.contactoService.GetProvincias();
            return new JsonResult(provincias);
        }
        [HttpPost("Cantones/{idProvincia?}")]
        public IActionResult Cantones(int idProvincia)
        {
            IList<TbCeCanton> cantones = new List<TbCeCanton>();
            cantones = this.contactoService.GetCantones(idProvincia);
            return new JsonResult(cantones);
        }
        [HttpPost("Distritos/{idDistrito?}/{idProvincia?}")]
        public JsonResult Distritos(int idDistrito, int idProvincia)
        {
            IList<TbCeDistrito> distritos = new List<TbCeDistrito>();
            distritos = this.contactoService.GetDistrito(idDistrito, idProvincia);
            return new JsonResult(distritos);
        }


    }
}