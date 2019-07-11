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

        [HttpGet("Todo/{nombreContacto?}")]
        public IActionResult ListarContactos(string nombreContacto)
        {
            ViewBag.nombre = "";
            if (nombreContacto != null)
                ViewBag.nombre = nombreContacto;
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

            var contacto = new ContactoViewModel();
            contacto.TipoCedula = "1";

            return View("CrearEditarContacto", contacto);
        }

        [HttpGet("Editar/{id}")]
        public IActionResult EditarContacto(int id)
        {

            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            ViewData["paises"] = paisService.GetAll();
            var contacto = contactoMap.DomainToViewModelC(contactoService.GetByIdContacto(id));


            return View("CrearEditarContacto", contacto);
        }

        [HttpPost("CrearEditarContacto")]
        public IActionResult CrearEditarContacto(IList<CCPersonalizadosViewModel> cpViewModel, ContactoViewModel cViewModel)
        {
            try
            {
                var existeContacto = contactoService.GetByCedulaContacto(cViewModel.Cedula);
                var contacto = new TbCrContacto();
                if (cViewModel.IdContacto != 0)
                {
                    if (existeContacto != null && existeContacto.IdContacto != cViewModel.IdContacto)
                    {
                        return Json(new { success = false });
                    }

                    contacto = contactoMap.UpdateContacto(cViewModel);
                    var listaCCPCrear = new List<CCPersonalizadosViewModel>();
                    var listaCCPAct = new List<CCPersonalizadosViewModel>();

                    foreach (var item in cpViewModel)
                    {
                        if (item.Id != 0)
                            listaCCPAct.Add(item);
                        else
                            listaCCPCrear.Add(item);
                    }

                    if (listaCCPCrear.Count() != 0)
                        ccMap.Create(listaCCPCrear, (int)cViewModel.IdContacto);
                    else
                        ccMap.Update(listaCCPAct, (int)cViewModel.IdContacto);


                    return Json(new { success = true, accion = true, id = contacto.IdContacto, nombre = contacto.Cedula });

                }
                else
                {
                    if (existeContacto != null)
                    {
                        return Json(new { success = false });
                    }

                    contacto = contactoMap.CreateContacto(cViewModel);
                    ccMap.Create(cpViewModel, (int)contacto.IdContacto);

                    return Json(new { success = true, accion = false, id = contacto.IdContacto });


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("GuardarImagen/{idContacto}")]
        public IActionResult GuardarImagen(int idContacto, IFormFile foto)
        {
            try
            {
                var contacto = contactoService.GetByIdContacto(idContacto);
                var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "uploads");
                contacto.Ruta = FotosService.SubirFotoContacto(foto, savePath);

                contactoService.Update(contacto);

                return Json(new { success = true });
            }
            catch (Exception)
            {
                return BadRequest();
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



        /// ///////////////////////////////////////////////relaciones entre contactos////////////////////////////////////////////////////

        [HttpPost("RelacionContacto")]
        public IActionResult _RelacionContacto(int idContacto)
        {

            var relacion = contactoService.GetContactoRelacion(idContacto);
            ViewBag.idContacto = idContacto;
            return PartialView(relacion);

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

        [HttpPost("_CrearEditarRelacion")]
        public IActionResult _CrearEditarRelacion(ContactoRelacionViewModel viewModel)
        {
            var contactos = contactoService.GetAll();
            ViewBag.contactos = contactos;
            ViewBag.contacto = contactos.FirstOrDefault(c => c.IdContacto == viewModel.IdContactoPadre);

            if (viewModel.Id != 0)
            {
                viewModel.Id = 0;
                viewModel.IdContactoPadre = 0;
                
                return PartialView(viewModel);
            }
            else
            {
                return PartialView(new ContactoRelacionViewModel());
            }

        }



        //metodo que va permitir guardar las relaciones 
        [HttpPost("CrearEditarRelacion")]
        public IActionResult CrearEditarRelacion(ContactoRelacionViewModel viewModel)
        {
            try
            {
                var contactoRel = contactoService.GetByIdPadreAndIdHijo((int)viewModel.IdContactoPadre, (int) viewModel.IdContactoHijo);
                if (contactoRel != null)
                {
                    contactoRel.NotaRelacion = viewModel.NotaRelacion;
                    var cr = contactoService.UpdateRelacion(contactoRel);
                }
                else
                {
                    var cr = this.contactoMap.CreateRelacion(viewModel);
                }

                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
                throw;
            }
        }


        /// /////////////////////////////////////////////// fin relaciones entre contactos////////////////////////////////////////////////////

        
            
            
            
        /// /////////////////////////////////////////////// tareas contactos////////////////////////////////////////////////////
        [HttpGet("_ListarTareasContacto/{idContacto}")]
        public IActionResult _ListarTareasContacto(int idContacto)
        {
            ViewData["usuarios"] = userService.GetAllByIdEmpresa((int)HttpContext.Session.GetInt32("idEmpresa"));
            return PartialView(contactoService.GetTareas(idContacto));
        }

        /// /////////////////////////////////////////////// fin tareas contactos////////////////////////////////////////////////////





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