using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.Mappers;
using AltivaWebApp.ViewModels;
using System.Security.Claims;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Controllers
{

    [Route("{culture}/Usuarios")]
    public class ManejoUsuariosController : Controller
    {
       
        IUserMap userMap;
        IUserService userService;
        IPerfilService perfilService;
        public EmailSender email;
        public void notificar(string mensaje)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            //email.insertarNotificacion(int.Parse(id), mensaje);

        }
        public ManejoUsuariosController(EmailSender email,IPerfilService perfilService, IUserMap map, IUserService userservice)
        {
            this.userMap = map;
            this.userService = userservice;
            this.perfilService = perfilService;
            this.email = email;
        }

        // GET: ManejoUsuarios
        [HttpGet("Lista-Usarios")]
        public ActionResult ListaUsuarios(string estado)
        {


            if (estado == null || estado == "" )   
                estado = "ACTIVO";

            ViewBag.estado = estado;

            var usariosFiltrados = new List<TbSeUsuario>();
            IList<TbSeUsuario> usuarios= userService.GetAll();

            foreach (var item in usuarios)
            {
                if(item.Estado == estado)
                {
                    usariosFiltrados.Add(item);
                }
            }

            return View(usariosFiltrados);

        }
        [Route("Cuenta-Usuario/{codigo?}")]
        public ActionResult CuentaUsuario(string codigo)
        {
            var model =  userService.GetUsuarioConPerfiles(codigo);
            //long id = model.Id;
            //ViewBag.id = id;
            var asignados = new List<TbSePerfil>();

            foreach (var item in model.TbSePerfilUsuario)
            {
                asignados.Add(item.IdPerfilNavigation);
            }

            var perfiles = perfilService.GetAll();
            var sinAsignar = new List<TbSePerfil>();

            foreach (var item in perfiles)
            {
                var flag = false;
                foreach (var i in asignados)
                {
                    if (item.Id == i.Id)
                    {
                        flag = true;
                        break;
                    }

                }
                if (!flag)
                    sinAsignar.Add(item);
            }

            ViewData["Asignados"] = asignados;
            ViewData["SinAsignar"] = sinAsignar;


            return View(userMap.DomainToViewModelSingle(model));
        }

        [Route("Cambiar-Configuracion")]
        public IActionResult CambiarConfig(ConfiguracionUViewModel config)
        {
            if (!ModelState.IsValid)
            {
                return View("MiCuenta");
            }

            var domain = new TbSeUsuarioConfiguraion
            {
                Idioma = config.Idioma,
                Tema = config.Tema,
                IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value)
        };

            var model = userService.CreateOrUpdateConfiguracion(domain);

            if (model != null)
                return Json(new { data = true });
            else
                return Json(new { data = false });
        }
        [HttpPost("Agregar-Perfil")]
        public ActionResult AsignarPerfil(IList<PerfilUsuarioViewModel> model)
        {

            var pu = userMap.CreatePU(model);
            notificar("Se ha asignado un nuevo perfil");
            if (pu)
                return Json(new { success = true });
            else
                return Json(new { success = false });

        }


        [Route("Quitar-Perfil/{usuario}/{id}")]
        public ActionResult QuitarPerfil(int usuario, int id)
        {
            var viewModel = new PerfilUsuarioViewModel
            {
                IdPerfil = id,
                IdUsuario = usuario
            };
            var domain = userService.GetPerfilUsuario(viewModel);

            var result = userService.DeletePU(domain);

            return RedirectToAction("CuentaUsuario", new { codigo = domain.IdUsuarioNavigation.Codigo });
        }

        // GET: ManejoUsuarios/Create
        [Route("Nuevo-Usuario")]
        public ActionResult CrearUsuario()
        {
            return View();
        }


      
        // POST: ManejoUsuarios/Create
        [HttpPost("Nuevo-Usuario")]
        [ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                model.Id_Usuario = Int32.Parse(id);


                if (userService.ExisteUsuarioPorCodigo(model.codigo))
                {
                    ModelState.AddModelError(string.Empty, "El código ya existe en el sistema");
                    return View(model);
                }
                    
                if (userService.ExisteUsuarioPorCorreo(model.correo))
                {
                    ModelState.AddModelError(string.Empty, "El correo ya existe en el sistema");
                    return View(model);
                }

                var user = userMap.Create(model);

                if(user != null)
                {
                    var uId = userService.GetUsuarioConPerfiles(user.codigo);
                    var idEmpresa =(int) HttpContext.Session.GetInt32("idEmpresa");
                    var empresaUsuarioRel = new TbSeEmpresaUsuario
                    {
                        IdEmpresa = idEmpresa,
                        Estado = true,
                        IdUsuario = uId.Id
                    };
                    var configUsuario = new TbSeUsuarioConfiguraion
                    {
                        Idioma= "es",
                        IdUsuario = uId.Id,
                        Tema = "TemaCombinado"
                    };

                    var resCU = userService.CreateOrUpdateConfiguracion(configUsuario);
                    var resEU = userService.CreateEmpresaUsuarioRel(empresaUsuarioRel);

                    if (resEU != null && resCU != null)
                        return RedirectToAction("CuentaUsuario", new { codigo = model.codigo });
                    else
                    {
                        userService.Delete(uId);
                        return View(string.Empty, "Error al crear la relación del usuario y la empresa");
                    }
                       
                }
                else
                {
                    return View(string.Empty, "Error al crear el usuario");
                }

                
            }
            catch
            {
                
                throw;                
            }
        }

        [Route("Editar-Usuario/{id}")]
        public ActionResult EditarUsuario(int id)
        {
            var model = userService.GetSingleUser(id);
            ViewBag.id = id;
            var modelView = userMap.DomainToViewModelSingle(model);
            return View(modelView);

        }
        [HttpPost("Editar-Usuario/{id?}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(UsuarioViewModel model)
        {
            string i = "";
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("ListaUsuarios");
                }

                var domain = userService.GetUsuarioConPerfiles(model.codigo);
                if(userService.ExisteUsuarioPorCodigo(model.codigo))
                    if(domain.Id != model.id)
                    {
                        ModelState.AddModelError(string.Empty, "El código ya existe en el sistema");
                        return View(model);
                    }

                var domain2 = userService.GetUsuarioConPerfiles(model.correo);

                if (userService.ExisteUsuarioPorCorreo(model.correo))
                    if (domain2.Id != model.id)
                    {
                        ModelState.AddModelError(string.Empty, "El correo ya existe en el sistema");
                        return View(model);
                    }

                var user = userMap.Update(model);
                i = user.Codigo;
                return RedirectToAction("ListaUsuarios");
                
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Lo sentimos, tuvimos un error al procesar tu solicitud");
                return RedirectToAction("ListaUsuarios");
            }
           

        }


        [HttpGet("Editar-Avatar/{codigo}/{img}")]
        public IActionResult EditarAvatar(string codigo,string img)
        {            
            var user = userService.GetUsuarioConPerfiles(codigo);

            string directorio = $"/avatars/{img}";



            user.Avatar = directorio;

            userService.UpdateUsuario(user);

            return RedirectToAction("CuentaUsuario", new { user.Codigo });
        }


        [HttpGet("Editar-Estado/{id}")]      
        public ActionResult EditarEstadoUsuario(int id)
        {
            try
            {
                // TODO: Add delete logic here


                var model = userService.GetSingleUser(id);

                var estado = model.Estado;

                if (model.Estado == "ACTIVO")
                {
                    model.Estado = "INACTIVO";
                }else
                    model.Estado = "ACTIVO";

                var user = userService.UpdateUsuario(model);
                if (user != null)
                {

                        return RedirectToAction("ListaUsuarios", new { estado = model.Estado});

                }
                else
                {
                    return RedirectToAction("ListaUsuarios");
                }
            }
            catch
            {
                return RedirectToAction("ListaUsuarios");
            }
        }
    }
}