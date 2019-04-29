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

namespace AltivaWebApp.Controllers
{

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
        public IcontactoCamposMap pContactoCamposMap;
     
        //
        public IEstadoTareaService IEstadoService;

        public ITipoTareaService ITipoService;
        public IUserService IUserService;
        //metodo usuasrios del sitemas
        public IUserRepository userMap;
        //variable de contactosCamposPersonalizadosService:
        public IContactoCamposService ICCService;
        public ContactoController(IUserService IUserService, ITipoTareaService ITipoService,IEstadoTareaService IEstadoService,FotosService pFotos, IUserRepository IUserRepository, IContactoCamposService ICCService, IContactoService contactoService, IContactoMap contactoMap, IcontactoCamposMap pContactoCamposMap, IcontactoCamposMap pContactoMap)
        {
            this.contactoService = contactoService;
            this.contactoMap = contactoMap;
            this.pContactoCamposMap = pContactoCamposMap;
            this.pContactoCamposMap = pContactoMap;
            this.ICCService = ICCService;
            this.userMap = IUserRepository;
            this.Fotos = pFotos;
            this.IUserService = IUserService;
            this.ITipoService = ITipoService;
            this.IEstadoService = IEstadoService;
            
            
        }


        public ActionResult Index(string palabra = "All")
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
                    } else if (palabra == conPersonas[j].Cedula)
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


        public JsonResult Details(int id)
        {

            ContactoViemModelDetalle contactoMap = new ContactoViemModelDetalle();
            contactoMap = this.contactoService.getById(id);
            ViewBag.id = contactoMap.Id;
            return new JsonResult(contactoMap);
        }

        public JsonResult Distritos(int idDistrito, int idProvincia)
        {
            IList<TbCeDistrito> distritos = new List<TbCeDistrito>();
            distritos = this.contactoService.GetDistrito(idDistrito, idProvincia);
            return new JsonResult(distritos);
        }

        public JsonResult Provincias()
        {
            IList<TbCeProvincias> provincias = new List<TbCeProvincias>();
            provincias = this.contactoService.GetProvincias();
            return new JsonResult(provincias);
        }

        public JsonResult Cantones(int idProvincia)
        {
            IList<TbCeCanton> cantones = new List<TbCeCanton>();
            cantones = this.contactoService.GetCantones(idProvincia);
            return new JsonResult(cantones);
        }
        public JsonResult Usuarios()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            IList<TbSeUsuario> USER = new List<TbSeUsuario>();
            USER = this.userMap.GetAllByIdUsuario(int.Parse(id));
            return new JsonResult(USER);
        }
        public ActionResult Create()
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
        public JsonResult editFoto(IFormCollection id, IFormFile foto)
        {
            IList<ContactoRelacionGETViewModel> cr = null;
            ViewData["contactoRelacion"] = cr;
            var idd = id["id"].ToString();
            string ruta = "";
            ruta = FotosService.SubirFotoContacto(foto);

            int i = Convert.ToInt32(idd);

            this.contactoMap.ingresarImagen(i, ruta);
            return new JsonResult(1);
        }
        [HttpPost]
        public JsonResult Crear(IList<CamposViewModel> model, ContactoViewModel model2)

        {
            //IList<CamposViewModel> model = new List<CamposViewModel>(); ContactoViewModel model2 = new ContactoViewModel();


            TbCrContacto contacto = new TbCrContacto();
            TbCrContacto correo = new TbCrContacto();
            TbCrContacto cedula = new TbCrContacto();

            IList<TbCrContactosCamposPersonalizados> contactosCampos = new List<TbCrContactosCamposPersonalizados>();
            try
            {
                correo = this.contactoService.GetByEmailContacto(model2.Correo);
                if (model2.TipoCedula == "CedulaFisica") {
                    cedula = this.contactoService.GetByCedulaContacto(model2.Cedula);
                }
                else if (model2.TipoCedula == "CedulaJuridica") {
                    cedula = this.contactoService.GetByCedulaContacto(model2.juridica);
                } else if (model2.dimex == "Dimex")

                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.dimex);

                } else if (model2.nite == "NITE")
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
                        this.pContactoCamposMap.Agregar(model, contacto.IdContacto);
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

        public JsonResult camposEdit(int id)
        {

            IList<ContactoViewModel> con = new List<ContactoViewModel>();
            con = this.ICCService.GetCamposEdit(id);
            return new JsonResult(con);
        }
        public JsonResult GetContactosRelacion(int id)
        {
            IList<ContactoRelacionGETViewModel> cr = new List<ContactoRelacionGETViewModel>();
            cr = this.contactoService.GetContactosRelacion(id);

            return new JsonResult(cr);
        }
        public ActionResult Edit(int id)
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


        public ActionResult Editar(IList<CamposViewModel> model1, ContactoViewModel model2)

        {

            try
            {

                TbCrContacto correo = new TbCrContacto();
                TbCrContacto cedula = new TbCrContacto();
                correo = this.contactoService.GetByEmailContacto(model2.Correo);
                if (correo != null)
                {
                    if (correo.IdContacto == model2.Id)
                    {

                    }
                    else
                    {
                        return Json(new { correo = "correo" });
                    }
                }
                if (model2.TipoCedula == "CedulaFisica")
                {

                    cedula = this.contactoService.GetByCedulaContacto(model2.Cedula);

                }
                else if (model2.TipoCedula == "CedulaJuridica")
                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.juridica);
                }
                else if (model2.dimex == "Dimex")

                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.dimex);

                }
                else if (model2.nite == "NITE")
                {
                    cedula = this.contactoService.GetByCedulaContacto(model2.nite);

                }

                if (cedula != null)
                {
                    if (cedula.IdContacto == model2.Id)
                    {

                    }
                    else
                    {
                        return Json(new { cedula = "cedula" });
                    }
                }
                TbCrContacto contacto;
                contacto = this.contactoMap.EditarContacto(model2);

                if (contacto != null)
                {
                    this.pContactoCamposMap.Update(model1, contacto.IdContacto);

                }
                return Json(new { id = contacto.IdContacto, correo = "libre", cedula = "Libre" });
            }
            catch
            {
                throw;
            }

        }

        //metodo que va permitir guardar las relaciones 
        [HttpPost]
        public JsonResult GuardarRelacion(ContactoRelacionViewModel domain)
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

        // GET: Contacto/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contacto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Partial()
        {
            ContactoViewModel con = new ContactoViewModel();

            return PartialView("subContacto.cshtml", new ContactoViewModel());
        }
        [HttpPost]
        public JsonResult EditarRelacion(EditarRelacionContactoViewModel domain)
        {
            TbCrContactoRelacion cr = new TbCrContactoRelacion();
            cr = this.contactoService.EditarRelacion(domain);
            
            return new JsonResult(true);
        }

        [HttpGet]
        public IActionResult GetTareas(int idContacto)
        {
            TbCrContacto ccT = new TbCrContacto();
            ccT = this.contactoService.GetTareas(idContacto);
            IList<TbFdTarea> tarea = new List<TbFdTarea>();
            foreach (var item in ccT.TbFdTarea)
            {
                item.IdContactoNavigation = null;
                item.IdEstadoNavigation.TbFdTarea = null;
                item.IdTipoNavigation.TbFdTarea = null;
                tarea.Add(item);
            }
            return Ok(tarea);
        }
    }

    
}