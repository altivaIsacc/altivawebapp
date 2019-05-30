using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.ViewModels;
using System.IO;
using AltivaWebApp.Services;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Mappers;

using AltivaWebApp.Repositories;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Mensajes")]
    public class MensajesController : Controller
    {


        //variable de interfaz service
        public IMensajeService ImensajeService;
        //variable de interfaz mapper 
        public IMensajeMap IMensajeMap;

        //variable de interfaz mapper Adjunto

        public IAdjuntoMap IAdjuntoMap;

        //sendEmail
        public EmailSender mailSender;
        // variable repository Archivos Adjuntos

        public IAdjuntoService IAdjuntoService;

        //Variable del usuario
        public IUserService IUserService;
        private readonly IHostingEnvironment hostingEnvironment;

        //variable pais service
        public IPaisService IPaisService;

        //variable repository de receptores

        //Variable mapper de mensajeReceptores
        public IMensajeReceptor IMensajeReceptorMap;

        //Variable service de mensajesReceptores
        public IMensajeReceptorService IMensajeReceptorService;
        //variable mapper bitacora.
        public IBitacoraMapper IBitacoraMap;



          
        
       
        public MensajesController(IPaisService IPaisService,IBitacoraMapper IBitacoraMa,IMensajeReceptorService pIMensajeReceptorService, IAdjuntoService IAdjuntoService, IMensajeReceptor pIMensajeReceptor, IMensajeService pImensajeService, IMensajeMap pIMensajeMap, IAdjuntoMap pIAdjuntoMap, IUserService pIUserService, IHostingEnvironment hostingEnvironment)
        {
            this.IPaisService = IPaisService;
            this.IBitacoraMap = IBitacoraMa;
            this.ImensajeService = pImensajeService;
            this.IMensajeMap = pIMensajeMap;
            this.IAdjuntoMap = pIAdjuntoMap;
            this.IAdjuntoService = IAdjuntoService;
            this.IUserService = pIUserService;
            this.hostingEnvironment = hostingEnvironment;
            this.IMensajeReceptorMap = pIMensajeReceptor;
            this.IMensajeReceptorService = pIMensajeReceptorService;
        }

        [HttpPost("Nuevo-Comentario")]
        public ActionResult CrearComentario(MensajeViewModel model)
        {
            return PartialView("_CrearComentario", model);
        }

        [Route("Lista-Comentarios")]
        public ActionResult ListarComentarios(ComentarioViewModel model)
        {
            var comentarios = ImensajeService.GetComentarios(model).ToList();
            return PartialView("_PartialComentarios", comentarios);
        }

        [HttpPost("Crear-ComentrioPost")]
        public ActionResult CrearComentarioPost(MensajeViewModel model)
        {
           

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;           

            TbSeAdjunto AdjuntoDomain = new TbSeAdjunto();

            List<TbSeAdjunto> listaAdjuntos = new List<TbSeAdjunto>();

            try
            {
                var comentario = this.IMensajeMap.Crear(model, int.Parse(id));
                comentario = this.ImensajeService.create(comentario);

                if (model.Files != null)
                {
                    var savePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "Files");
                    var rutas = FotosService.SubirAdjuntos(model.Files, savePath);
                    foreach (var item in rutas)
                    {
                        AdjuntoDomain = this.IAdjuntoMap.crear(comentario.Id, item);
                        listaAdjuntos.Add(AdjuntoDomain);
                    }

                    
                }
                else
                {
                    AdjuntoDomain = this.IAdjuntoMap.crear(comentario.Id, "");

                    listaAdjuntos.Add(AdjuntoDomain);
                }

                this.IAdjuntoService.Crear(listaAdjuntos);

                return Json(new { success = true });
            }
            catch (Exception)
            {
                //return BadRequest();
                throw;
            }            
           
                      

        }

        
        [Route("Eliminar-Comentario/{idComentario}")]
        public ActionResult EliminarComentario(int idComentario)
        {           
            try
            {
                var msj = IMensajeMap.EliminarComentario(idComentario);
                ImensajeService.Update(msj);
                       
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return BadRequest();
            }
                      
        }

        [HttpGet("Mensajes")]
        public ActionResult Index()
        {

            List<TbSeUsuario> usuariosAsociados = new List<TbSeUsuario>();

            ViewData["usuarios"] = this.IUserService.GetSingleUser(74);

            return View();
        }

        [Route("BuscarNombre/{idUsuario}")]
        public JsonResult BuscarNombre(int idUsuario)
        {
            List<MensajeRecibidoViewModel> nombreReceptor = new List<MensajeRecibidoViewModel>();
            nombreReceptor = this.ImensajeService.BuscarNombre(idUsuario);
            return new JsonResult(nombreReceptor);
        }
        [Route("VerMensaje/{idMensaje}")]
        public JsonResult VerMensaje(int idMensaje)
        {
            List<MensajeRecibidoViewModel> ms = new List<MensajeRecibidoViewModel>();
            ms = this.ImensajeService.Ver(idMensaje);
            return new JsonResult(ms);
        }

        public ActionResult GetComentarios(int valor)
        {
            List<MensajeRecibidoViewModel> ms = new List<MensajeRecibidoViewModel>();
            ms = this.ImensajeService.VerComentarios(valor);
            return new JsonResult(ms);
        }
        [Route("Eliminar/{idMensaje}")]
        public JsonResult Eliminar(int idMensaje)
        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
      
            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            re = this.IMensajeReceptorMap.EliminarTemporal(idMensaje);
            this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Paso un mensaje a estado eliminado",re.IdMensaje,"Mensaje");
            this.IMensajeReceptorService.Update(re);
            return Json(new { id = 1 });
        }
        //metodo que muestra los mensajes archivados
        [Route("Archivados")]
        public ActionResult Archivados()
        {
            List<MensajeRecibidoViewModel> MensajeViewModel = new List<MensajeRecibidoViewModel>();

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            MensajeViewModel = this.ImensajeService.Archivados(int.Parse(id));
            ViewData["Archivados"] = MensajeViewModel;
            return View();

        }
         [Route("NoLeidos/{pMensaje}")]
        public JsonResult NoLeidos(int pMensaje)
        {
            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            re = this.IMensajeReceptorMap.NoLeido(pMensaje);
            this.IMensajeReceptorService.Update(re);
            return Json(new { id = 1 });

        }
        [Route("Leidos/{pMensaje}")]
        public JsonResult Leidos(int pMensaje)
        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            
            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            re = this.IMensajeReceptorMap.Leido(pMensaje);
            this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Vio un mensaje recibido",re.IdMensaje,"Mensaje");

            this.IMensajeReceptorService.Update(re); ;
            return Json(new { id = 1 });

        }
        //enviados
        [Route("Enviados")]
        public ActionResult Enviados()
        {
            List<MensajeRecibidoViewModel> MensajeViewModel = new List<MensajeRecibidoViewModel>();

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            MensajeViewModel = this.ImensajeService.Enviados(int.Parse(id));
            ViewData["MensajeEnviados"] = MensajeViewModel;
            return View();
        }
        //filtrp por usuario
        [Route("FilterByName")]

      
        public IActionResult FilterByName(string valor)
        {

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            List<MensajeRecibidoViewModel> f = new List<MensajeRecibidoViewModel>();
            f = this.ImensajeService.FilterByName(int.Parse(id), valor);



            return new JsonResult(f);
        }
        //contador
        [Route("Contador")]
        public JsonResult Contador()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            int w = this.ImensajeService.Contador(int.Parse(id));
    
                ViewBag.contador = w;
            
            return Json(new { contador = w });
        }
        [HttpGet("BandejaDeEntrada/{id?}")]
        public ActionResult Recibidos(int id = 1)
        {
            List<MensajeRecibidoViewModel> MensajeViewModel1 = new List<MensajeRecibidoViewModel>();
            List<MensajeRecibidoViewModel> MensajeViewModel2 = new List<MensajeRecibidoViewModel>();
            List<MensajeRecibidoViewModel> MensajeViewModel3 = new List<MensajeRecibidoViewModel>();
            ViewBag.id = id;
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            MensajeViewModel1 = this.ImensajeService.Recibido(int.Parse(ids));

            ViewData["MensajeRecibido"] = MensajeViewModel1;
            MensajeViewModel2 = this.ImensajeService.Enviados(int.Parse(ids));
            ViewData["MensajeEnviados"] = MensajeViewModel2;
            MensajeViewModel3 = this.ImensajeService.Archivados(int.Parse(ids));
            ViewData["Archivados"] = MensajeViewModel3;
            return View();
        }
        [HttpGet("CambiarEstado/{idMensaje}")]
        public JsonResult CambiarEstado(int idMensaje)
        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
          
            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            re = this.IMensajeReceptorMap.Edit(idMensaje);
            this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Paso un mensaje a estado archivado",re.IdMensaje,"Mensajes");

            this.IMensajeReceptorService.Update(re);
            return Json(new { id = 1 });
        }

        [HttpPost("CrearMensaje/")]
        public ActionResult Crear(MensajeViewModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(nameof(Index));

                var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


                var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                MensajeViewModel adjunto = new MensajeViewModel();
                TbSeMensaje msj = new TbSeMensaje();
                TbSeMensajeReceptor msjReceptor = new TbSeMensajeReceptor();
                TbSeAdjunto AdjuntoDomain = new TbSeAdjunto();

                List<TbSeAdjunto> s = new List<TbSeAdjunto>();

                List<TbSeMensajeReceptor> MensajeReceptor = new List<TbSeMensajeReceptor>();
                msj = this.IMensajeMap.Crear(collection, int.Parse(id));
                msj = this.ImensajeService.create(msj);
                List<string> correos = new List<string>();
                TbSeUsuario userEmail = new TbSeUsuario();
                if (collection.Files != null)
                {
                    foreach (var item in collection.Files)
                    {
                        var savePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "Files");
                        // var path = $"wwwroot\\Files\\{item.FileName}";
                        var path = $"{savePath}\\{item.FileName}";
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            item.CopyTo(stream);

                        }

                       var ruta = $"/Files/{item.FileName}";
                        AdjuntoDomain = this.IAdjuntoMap.crear(msj.Id, ruta);

                        s.Add(AdjuntoDomain);

                    }

                }
                else
                {
                    AdjuntoDomain = this.IAdjuntoMap.crear(msj.Id, "");

                    s.Add(AdjuntoDomain);
                }
                this.IAdjuntoService.Crear(s);
                foreach (var item in collection.Usuarios)
                {
                    int i = int.Parse(item);

                    userEmail = this.IUserService.GetSingleUser(i);
                    correos.Add(userEmail.Correo);
                    msjReceptor = this.IMensajeReceptorMap.Crear(msj.Id, i);
                    MensajeReceptor.Add(msjReceptor);
                }
                this.IMensajeReceptorService.Crear(MensajeReceptor);
                //   insertarNotificacion(collection, int.Parse(id), correos);

                this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Creo un nuevo Mensaje", msj.Id, "Mensaje");
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidCastException e)
            {
                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
                }
            }
        
        [HttpPost("ModificarEstados")]
        public ActionResult ModificarEstados(List<int> id)
        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            foreach (var i in id)
            {
                re = this.IMensajeReceptorMap.Edit(i);
                this.IMensajeReceptorService.Update(re);

                this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Archivo todos los mensajes recibidos",re.IdMensaje,"Mensajes");
            }
            return Json(new { });
        }
        public void InsertarNotificacion(MensajeViewModel collection, int msjId, List<string> correos)
        {
            List<TbSeMensajeReceptor> mensajeReceptor = new List<TbSeMensajeReceptor>();
            TbSeMensaje notificacion = new TbSeMensaje("Se notifica el envio en un mensaje", "NO", msjId);
            this.ImensajeService.create(notificacion);
            foreach (var item in collection.Usuarios)
            {
                int i = int.Parse(item);



                mensajeReceptor.Add(this.IMensajeReceptorMap.Crear(msjId, i));
            }
            this.IMensajeReceptorService.Crear(mensajeReceptor);
            foreach (var correo in correos)
            {

                EmailSender.emailSender(correo, notificacion.Mensaje, "Mensaje del Sistema Altiva Soluciones Seguridad");

            }
        }

        
    }
}