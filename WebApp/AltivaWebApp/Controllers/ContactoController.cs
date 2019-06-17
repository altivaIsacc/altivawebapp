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
    [Route("{culture}/Contacto")]
    public class ContactoController : Controller
    {
        //
        public FotosService Fotos;
        //variable service
        public IContactoService contactoService;
        //
        public IcontactoCamposMap pContactoMap;
        //
        public IContactoMap contactoMap;
        // GET: Contacto
        public IcontactoCamposMap contactoCamposMap;

        //
        public IEstadoTareaService IEstadoService;

        public ITipoTareaService ITipoService;
        public IUserService IUserService;
        private readonly IHostingEnvironment hostingEnvironment;

        //metodo usuasrios del sitemas
        public IUserRepository userMap;
        //variable de contactosCamposPersonalizadosService:
        public IContactoCamposService ICCService;
        public ContactoController(IUserService IUserService, IHostingEnvironment hostingEnvironment, ITipoTareaService ITipoService, IEstadoTareaService IEstadoService, FotosService pFotos, IUserRepository IUserRepository, IContactoCamposService ICCService, IContactoService contactoService, IContactoMap contactoMap, IcontactoCamposMap pContactoCamposMap)
        {
            this.contactoService = contactoService;
            this.contactoMap = contactoMap;
            contactoCamposMap = pContactoCamposMap;
            this.ICCService = ICCService;
            userMap = IUserRepository;
            Fotos = pFotos;
            this.IUserService = IUserService;
            this.hostingEnvironment = hostingEnvironment;
            this.ITipoService = ITipoService;
            this.IEstadoService = IEstadoService;

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
                return new JsonResult(cb);
            }
            else
            {
                return Ok(false);
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
        [HttpGet("Index/{palabra?}")]
        public IActionResult Index(string palabra = "All")
        {



            IList<TbCrContacto> buscar = new List<TbCrContacto>();
            IList<TbCrContacto> conPersonas = new List<TbCrContacto>();
            IList<TbCrContacto> abecedario = new List<TbCrContacto>();
            conPersonas = this.contactoService.GetAll();
            string nombre;
            string nombreComercial;
            if (palabra.Length > 3)
            {
                for (int j = 0; j < conPersonas.Count; j++)
                {

                    if (conPersonas[j].Nombre != null)
                    {
                        nombre = conPersonas[j].Nombre;
                        if (nombre == palabra)
                        {
                            buscar.Add(conPersonas[j]);
                        }
                    }
                    else
                    {
                        nombreComercial = conPersonas[j].NombreComercial;
                        if (nombreComercial == palabra)
                        {

                            buscar.Add(conPersonas[j]);
                        }
                    }
                    if (palabra == conPersonas[j].Correo)
                    {
                        buscar.Add(conPersonas[j]);
                    }
                    else if (palabra == conPersonas[j].Cedula)
                    {
                        buscar.Add(conPersonas[j]);
                    }
                }
                ViewData["conPersonas"] = buscar;

            }
            else
            {


                if (palabra == "All")
                {

                    ViewData["conPersonas"] = conPersonas;
                }
                else
                {

                    for (int i = 0; i < conPersonas.Count; i++)
                    {

                        if (conPersonas[i].Nombre != null)
                        {
                            nombre = conPersonas[i].Nombre.Substring(0, 1);
                            if (nombre == palabra)
                            {
                                abecedario.Add(conPersonas[i]);
                            }
                        }
                        else
                        {
                            nombreComercial = conPersonas[i].NombreComercial.Substring(0, 1);
                            if (nombreComercial == palabra)
                            {
                                abecedario.Add(conPersonas[i]);
                            }
                        }
                    }
                    ViewData["conPersonas"] = abecedario;
                }
            }
            return View();
        }

        [HttpGet("Details/{id?}")]
        public IActionResult Details(int id)
        {

            ContactoViemModelDetalle contactoMap = new ContactoViemModelDetalle();
            contactoMap = this.contactoService.getById(id);
            ViewBag.id = contactoMap.Id;
            return new JsonResult(contactoMap);
        }
        [HttpPost("Distritos/{idDistrito?}/{idProvincia?}")]
        public JsonResult Distritos(int idDistrito, int idProvincia)
        {
            IList<TbCeDistrito> distritos = new List<TbCeDistrito>();
            distritos = this.contactoService.GetDistrito(idDistrito, idProvincia);
            return new JsonResult(distritos);
        }
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
        [HttpGet("Usuarios")]
        public IActionResult Usuarios()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            IList<TbSeUsuario> USER = new List<TbSeUsuario>();
            USER = this.userMap.GetAllByIdUsuario(int.Parse(id));
            return new JsonResult(USER);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            IList<TbSeUsuario> USER = new List<TbSeUsuario>();
            USER = this.userMap.GetAllByIdUsuario(int.Parse(id));
            IList<TbCrContacto> contactos = new List<TbCrContacto>();
            contactos = this.contactoService.GetAll();
            ViewData["Contactos"] = this.contactoService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewData["estados"] = this.IEstadoService.GetAll();
            ViewData["tipos"] = this.ITipoService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewData["Usuarios"] = USER;
            ViewData["contactos"] = contactos;
            return View();
        }
        [HttpGet("editFoto")]
        public IActionResult editFoto(IFormCollection id, IFormFile foto)
        {
            IList<ContactoRelacionGETViewModel> cr = null;
            ViewData["contactoRelacion"] = cr;
            var idd = id["id"].ToString();
            string ruta = "";
            var savePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "uploads");

            ruta = FotosService.SubirFotoContacto(foto,savePath);

            int i = Convert.ToInt32(idd);

            this.contactoMap.ingresarImagen(i, ruta);
            return new JsonResult(1);
        }
        [HttpPost("Crear")]
        public IActionResult Crear(IList<CamposViewModel> model, ContactoViewModel model2)

        {
            //IList<CamposViewModel> model = new List<CamposViewModel>(); ContactoViewModel model2 = new ContactoViewModel();


            TbCrContacto contacto = new TbCrContacto();
            TbCrContacto correo = new TbCrContacto();
            TbCrContacto cedula = new TbCrContacto();

            IList<TbCrContactosCamposPersonalizados> contactosCampos = new List<TbCrContactosCamposPersonalizados>();
            try
            {
                correo = contactoService.GetByEmailContacto(model2.Correo);
                cedula = contactoService.GetByCedulaContacto(model2.Cedula);
                if (model2.TipoCedula == "1")
                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.Cedula);
                }
                else if (model2.TipoCedula == "2")
                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.juridica);
                }
                else if (model2.dimex == "3")

                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.dimex);

                }
                else if (model2.nite == "4")
                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.nite);

                }

                if (cedula != null)
                {
                    return Json(new { cedula = "cedula" });
                }
                if (correo != null)
                {
                    return Json(new { correo = "correo" });
                }

                if (model != null || model2 != null)
                {
                    contacto = this.contactoMap.NuevoContacto(model2);
                    if (contacto != null)
                    {
                        this.contactoCamposMap.Agregar(model, contacto.IdContacto);
                    }
                }

                model = null;
                model2 = null;
                return Json(new { id = contacto.IdContacto, correo = "libre", cedula = "Libre" });
            }
            catch
            {
                throw;
            }


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
            IList<ContactoRelacionGETViewModel> cr = new List<ContactoRelacionGETViewModel>();
            cr = this.contactoService.GetContactosRelacion(id);
            ContactoViewModel contacto = new ContactoViewModel();
            contacto = this.contactoService.GetByEdit(id);
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            IList<TbCrContacto> contactos = new List<TbCrContacto>();
            contactos = this.contactoService.GetAll();
            ViewData["Contactos"] = this.contactoService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewData["estados"] = this.IEstadoService.GetAll();
            ViewData["tipos"] = this.ITipoService.GetAll();
            ViewData["Asignados"] = this.IUserService.GetAll();
            ViewData["contactoRelacion"] = cr;
            ViewData["contactos"] = contactos;
            IList<TbSeUsuario> USER = new List<TbSeUsuario>();
            USER = this.userMap.GetAllByIdUsuario(int.Parse(ids));
            ViewData["Usuarios"] = USER;
            return View(contacto);
        }

        // POST: Contacto/Edit/5

        [HttpPost("Editar")]
        public IActionResult Editar(IList<CamposViewModel> model1, ContactoViewModel model2)

        {
            try
            {

                TbCrContacto correo = new TbCrContacto();
                TbCrContacto cedula = new TbCrContacto();
                correo = this.contactoService.GetByEmailContacto(model2.Correo);
                if (correo != null)
                {
                    if (correo.IdContacto != model2.Id)
                    {
                        return Json(new { correo = "correo" });
                    }
                   
                }
                if (model2.TipoCedula == "1")
                {

                    cedula = this.contactoService.GetByCedulaContacto(model2.Cedula);

                }
                else if (model2.TipoCedula == "2")
                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.juridica);
                }
                else if (model2.TipoCedula == "3")

                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.dimex);

                }
                else if (model2.TipoCedula == "4")
                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.nite);
                }

                if (cedula != null)
                {
                    if (cedula.IdContacto != model2.Id)
                    {
                        return Json(new { cedula = "cedula" });
                    }
                }
                TbCrContacto contacto;
                contacto = this.contactoMap.EditarContacto(model2);

                if (contacto != null)
                {
                    this.contactoCamposMap.Update(model1, contacto.IdContacto);
                }
                return Json(new { id = contacto.IdContacto, correo = "libre", cedula = "Libre" });
            }
            catch
            {
                throw;
            }

        }

        //metodo que va permitir guardar las relaciones 
        [HttpPost("GuardarRelacion")]
        public IActionResult GuardarRelacion(ContactoRelacionViewModel domain)
        {
            try
            {
                TbCrContactoRelacion cr = new TbCrContactoRelacion();
                cr = this.contactoMap.InsertarRelacion(domain);
            }
            catch
            {
                throw;
            }
            return new JsonResult(1);
        }


        [HttpGet("Partial")]
        public IActionResult Partial()
        {
            ContactoViewModel con = new ContactoViewModel();

            return PartialView("subContacto.cshtml", new ContactoViewModel());
        }
        [HttpPost("EditarRelacion")]
        public IActionResult EditarRelacion(EditarRelacionContactoViewModel domain)
        {
            TbCrContactoRelacion cr = new TbCrContactoRelacion();
            cr = this.contactoService.EditarRelacion(domain);

            return new JsonResult(true);
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
                return Ok(contactoService.GetAllProveedores());
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


    }
}