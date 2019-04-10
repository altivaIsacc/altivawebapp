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

namespace AltivaWebApp.Controllers
{

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

        //variable pais service
        public IPaisService IPaisService;

        //variable repository de receptores

        //Variable mapper de mensajeReceptores
        public IMensajeReceptor IMensajeReceptorMap;

        //Variable service de mensajesReceptores
        public IMensajeReceptorService IMensajeReceptorService;
        //variable mapper bitacora.
        public IBitacoraMapper IBitacoraMap;
        //Constructrua Mensahjes controlador

            //variable de mensaje service

        public MensajesController(IPaisService IPaisService,IBitacoraMapper IBitacoraMa,IMensajeReceptorService pIMensajeReceptorService, IAdjuntoService IAdjuntoService, IMensajeReceptor pIMensajeReceptor, IMensajeService pImensajeService, IMensajeMap pIMensajeMap, IAdjuntoMap pIAdjuntoMap, IUserService pIUserService)
        {
            this.IPaisService = IPaisService;
            this.IBitacoraMap = IBitacoraMa;
            this.ImensajeService = pImensajeService;
            this.IMensajeMap = pIMensajeMap;
            this.IAdjuntoMap = pIAdjuntoMap;
            this.IAdjuntoService = IAdjuntoService;
            this.IUserService = pIUserService;
         
            this.IMensajeReceptorMap = pIMensajeReceptor;
            this.IMensajeReceptorService = pIMensajeReceptorService;
        }

        public ActionResult Partial()
        {

            ViewBag.id = 1;
            return  PartialView("_PartialComentario", ViewBag.id);
        }

        public ActionResult CrearComentario(MensajeViewModel model)
        {
            return PartialView("_PartialComentarios", model);
        }

        //insertComentarioPais
        public ActionResult CrearComentarioPais(MensajeViewModel collection)
        {

            collection.tipoReferencia = "Pais";
            collection.tipoMensaje = "CO";

            if (!ModelState.IsValid)
                return RedirectToAction("CrearReferenciaPais", new { @id = collection.id });

            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            MensajeViewModel adjunto = new MensajeViewModel();
            TbSeMensaje msj = new TbSeMensaje();

            TbSeAdjunto AdjuntoDomain = new TbSeAdjunto();

            List<TbSeAdjunto> s = new List<TbSeAdjunto>();

            msj = this.IMensajeMap.Crear(collection, int.Parse(id));
            msj = this.ImensajeService.create(msj);

            if (collection.Files != null)
            {
                foreach (var item in collection.Files)
                {

                    var path = $"wwwroot\\Files\\{item.FileName}";
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
           
                ViewBag.modal = 1;
                return RedirectToAction("CrearReferenciaPais", new { @id = collection.id });
           

        }

        //post
       public ActionResult CrearComentarioUser(MensajeViewModel collection)
        {
            collection.tipoReferencia = "Usuario";
            collection.tipoMensaje = "CO";

            if (!ModelState.IsValid)
            {
              
                    return RedirectToAction("CrearComentarioUsuario", new { @id = collection.id });
         
            }
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            MensajeViewModel adjunto = new MensajeViewModel();
            TbSeMensaje msj = new TbSeMensaje();
       
            TbSeAdjunto AdjuntoDomain = new TbSeAdjunto();

            List<TbSeAdjunto> s = new List<TbSeAdjunto>();

            msj = this.IMensajeMap.Crear(collection, int.Parse(id));
            msj = this.ImensajeService.create(msj);
    
            if (collection.Files != null)
            {
                foreach (var item in collection.Files)
                {

                    var path = $"wwwroot\\Files\\{item.FileName}";
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
          
                return RedirectToAction("CrearComentarioUsuario", new { @id = collection.id });
            
        }
        // GET: Mensajes
        [HttpGet("/Comentario/Pais/{id?}")]
        public ActionResult CrearComentarioUsuario(int id)
        {
            List<MensajeRecibidoViewModel> ms = new List<MensajeRecibidoViewModel>();
            TbSeUsuario usuario = new TbSeUsuario();
            // GetSingleUser
            usuario= this.IUserService.GetSingleUser(id);
            ViewBag.nombre = usuario.Nombre;
            ViewBag.codigo = usuario.Codigo;
            //id del usuario
            ms = this.ImensajeService.VerComentariosUsuarios(id);
            ViewData["comentarioUsuario"] = ms;
            ViewBag.id = id;
            return View();
        }
        //eliminar comentario pais

        public ActionResult EliminarComentario(int idComentario)
        {           
            try
            {
                var msj = IMensajeMap.EliminarComentario(idComentario);
                this.ImensajeService.Update(msj);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                //throw;
            }
                      
        }

        public ActionResult EliminarComentarioPais(int id, int codigo)
        {
            TbSeMensaje msj;
            msj = IMensajeMap.EliminarComentario(id);

            this.ImensajeService.Update(msj);
            return RedirectToAction("CrearReferenciaPais", new { @id = codigo });
        }
        //Eliminar comentario usuario

        public ActionResult EliminarComentarioUsuario(int id,int codigo)
        {
            TbSeMensaje msj;
            msj=  IMensajeMap.EliminarComentario(id);

            this.ImensajeService.Update(msj);
            return RedirectToAction("CrearComentarioUsuario", new { @id = codigo });
        }

                [HttpGet("/Comentario/usuario/{id?}")]
        public ActionResult CrearReferenciaPais(int id)
        {
            List<MensajeRecibidoViewModel> ms = new List<MensajeRecibidoViewModel>();
            TbSePais pais = new TbSePais();
            pais = this.IPaisService.GetPaisById(id);
            ViewBag.nombre = pais.NombreEs;
            ms = this.ImensajeService.ComentarioByPais(id);
            ViewData["comentarioPais"] = ms;
            //id del pais 
            ViewBag.id = id;
            return View();
        }
        [HttpGet("/Mensajes/")]
        public ActionResult Index()
        {

            List<TbSeUsuario> usuariosAsociados = new List<TbSeUsuario>();

            ViewData["usuarios"] = this.IUserService.GetSingleUser(74);

            return View();
        }
        public JsonResult BuscarNombre(int valor)
        {
            List<MensajeRecibidoViewModel> nombreReceptor = new List<MensajeRecibidoViewModel>();
            nombreReceptor = this.ImensajeService.BuscarNombre(valor);
            return new JsonResult(nombreReceptor);
        }
        public JsonResult verMensaje(int valor)
        {
            List<MensajeRecibidoViewModel> ms = new List<MensajeRecibidoViewModel>();
            ms = this.ImensajeService.Ver(valor);
            return new JsonResult(ms);
        }

        public JsonResult verComentario(int valor)
        {
            List<MensajeRecibidoViewModel> ms = new List<MensajeRecibidoViewModel>();
            ms = this.ImensajeService.VerComentarios(valor);
            return new JsonResult(ms);
        }
        public JsonResult Eliminar(int valor)
        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
      

            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            re = this.IMensajeReceptorMap.EliminarTemporal(valor);
            this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Paso un mensaje a estado eliminado",re.IdMensaje,"Mensaje");
            this.IMensajeReceptorService.Update(re);
            return Json(new { id = 1 });
        }
        //metodo que muestra los mensajes archivados
        public ActionResult Archivados()
        {
            List<MensajeRecibidoViewModel> MensajeViewModel = new List<MensajeRecibidoViewModel>();

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            MensajeViewModel = this.ImensajeService.Archivados(int.Parse(id));
            ViewData["Archivados"] = MensajeViewModel;
            return View();

        }
        
        public JsonResult NoLeidos(int valor)
        {
            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            re = this.IMensajeReceptorMap.NoLeido(valor);
            this.IMensajeReceptorService.Update(re);
            return Json(new { id = 1 });

        }
        public JsonResult Leidos(int valor)
        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            
            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            re = this.IMensajeReceptorMap.Leido(valor);
            this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Vio un mensaje recibido",re.IdMensaje,"Mensaje");

            this.IMensajeReceptorService.Update(re); ;
            return Json(new { id = 1 });

        }
        //enviados
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
        public JsonResult Contador()
        {

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            int w = this.ImensajeService.Contador(int.Parse(id));
    
                ViewBag.contador = w;
            
            return Json(new { contador = w });
        }
        [HttpGet("/BandejaDeEntrada/{id?}")]
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
        public JsonResult CambiarEstado(int valor)
        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
          
            TbSeMensajeReceptor re = new TbSeMensajeReceptor();
            re = this.IMensajeReceptorMap.Edit(valor);
            this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Paso un mensaje a estado archivado",re.IdMensaje,"Mensajes");

            this.IMensajeReceptorService.Update(re);
            return Json(new { id = 1 });
        }

        [HttpPost("/CrearMensaje/")]
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

                        var path = $"wwwroot\\Files\\{item.FileName}";
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
        public void insertarNotificacion(MensajeViewModel collection, int msjId, List<string> correos)
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

        // POST: Mensajes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Mensajes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mensajes/Delete/5
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
    }
}