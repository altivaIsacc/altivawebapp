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
        private readonly IUserService userService;
        private readonly IContactoCamposService ccService;
        private readonly IPaisService paisService;
        private readonly ICamposPersonalizadosService cpService;
        private readonly IMonedaService monedaService;

        public ContactoController(IMonedaService monedaService, ICamposPersonalizadosService cpService, IPaisService paisService, IUserService IUserService, IContactoCamposService ICCService, IContactoService contactoService, IContactoMap contactoMap, IContactoCamposMap pContactoCamposMap)
        {
            this.contactoService = contactoService;
            this.contactoMap = contactoMap;
            ccMap = pContactoCamposMap;
            this.ccService = ICCService;
            this.userService = IUserService;
            this.paisService = paisService;
            this.cpService = cpService;
            this.monedaService = monedaService;

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

        [HttpGet("GetAllClientes")]
        public IActionResult GetAllClientes()
        {
            try
            {
                return Ok(contactoService.GetAllClientes());
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
        public IActionResult CrearEditarContacto(IList<CCPersonalizadosViewModel> cpViewModel, ContactoViewModel cViewModel, IList<TbFdCondicionesDePago> cPagoViewModel)
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

                    contactoService.CreateOrUpdateCondicionPago(cPagoViewModel);

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

                    foreach (var item in cPagoViewModel)
                    {
                        item.IdContacto = contacto.IdContacto;
                    }

                    contactoService.CreateOrUpdateCondicionPago(cPagoViewModel);

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

        [HttpGet("GetUsuarioCliente")]
        public ActionResult GetUsuariosCliente()
        {
            return Ok(contactoService.GetAllClientes());
        }

        [HttpGet("camposEdit/{id?}")]
        public IActionResult camposEdit(int id)
        {

            IList<ContactoViewModel> con = new List<ContactoViewModel>();
            con = this.ICCService.GetCamposEdit(id);
            return new JsonResult(con);
        }

        [HttpGet("GetContactosRelacion/{id?}")]
        public IActionResult GetContactosRelacion(int id)
        {
            IList<ContactoRelacionGETViewModel> cr = new List<ContactoRelacionGETViewModel>();
            cr = this.contactoService.GetContactosRelacion(id);

            return new JsonResult(cr);
        }

        [HttpGet("Edit/{id?}")]
        public IActionResult Edit(int id)
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


        
        ///////////////////////////////////////////////////////////////////////condiciones de pago
       
        [HttpGet("GetCondicionesPago/{idContacto}")]
        public IActionResult GetCondicionesPago(int idContacto)
        {
            try
            {
                return Ok(contactoService.GetCondicionesByIdContacto(idContacto));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        ///////////////////////////////////////////////////////////////////fin condiciones de pago//////////////////////////////////////////////
        


        /////////////////////////////////////////////////////////////////cuentas bancarias//////////////////////////////////////////////////

        [HttpGet("_ListarCuentasBancarias/{idContacto}")]
        public IActionResult _ListarCuentasBancarias(int idContacto)
        {
            ViewBag.idContacto = idContacto;
            return View(contactoService.GetCuentasByContacto(idContacto));
        }

        [HttpPost("_CrearEditarCuentasBancarias")]
        public IActionResult _CrearEditarCuentasBancarias(int idCuenta, int idContacto)
        {
            ViewBag.monedas = monedaService.GetAll();
            if(idCuenta != 0)
            {
                return PartialView(contactoMap.DomainToViewModelCB(contactoService.GetCuentaById(idCuenta)));
            }
            else
            {
                var modelo = new CuentaBancariaViewModel
                {
                    IdContacto = idContacto
                };
                return PartialView(modelo);
            }
        }

        [HttpPost("CrearEditarCuentasBancarias")]
        public IActionResult CrearEditarCuentasBancarias(CuentaBancariaViewModel viewModel)
        {
            try
            {
                var cuenta = new TbFdCuentasBancarias();
                if(viewModel.Id != 0)
                {
                    contactoMap.UpdateCuentaBancaria(viewModel);
                }
                else
                {
                    contactoMap.CreateCuentaBancaria(viewModel);
                }

                return Json(new { success = true });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("EliminarCuentaBancaria")]
        public IActionResult EliminarCuentaBancaria(int idCuenta)
        {
            try
            {
                contactoService.DeleteCuentasBancarias(contactoService.GetCuentaById(idCuenta));
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }


        /////////////////////////////////////////////////////////////////////////////fin cuentas bancarias/////////////////////////////////////////////

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


        [HttpGet("GetCliente")]
        public IActionResult GetAllClientes(int idContacto)
        {
            try
            {
                return Ok(contactoService.GetAllClientes());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}