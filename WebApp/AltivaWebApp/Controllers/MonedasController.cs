using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Mappers;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using AltivaWebApp.ViewModels;
using System.Globalization;
using System.Security.Claims;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Moneda")]
    public class MonedasController : Controller
    {

        public IUserRepository IUserRepository;
        public IMensajeService ImensajeService;
        public IMensajeReceptor IMensajeReceptorMap;
        public IMensajeReceptorRepository IMensajeReceptorRepository;


        //variable de interfaz mapper 
        public IMensajeMap IMensajeMap;

        private IMonedaMap monedaMap;
        private IHistorialMonedaMap HistorialMap;
        private IMonedaService monedaService;
        private IHistorialMonedaService historialService;
        public EmailSender emailSender;

        private IBitacoraMapper IBitacoraMap;

        public MonedasController(IBitacoraMapper IBitacoraMap,IMensajeReceptorRepository IMensajeReceptorRepository,IMensajeMap IMensajeMap, IUserRepository IUserRepository, IMensajeService ImensajeService, IMensajeReceptor IMensajeReceptorMap, IMonedaMap monedaMap, IMonedaService monedaService, IHistorialMonedaService pHistorialService, IHistorialMonedaMap pHistorialMap, EmailSender emailSender)
        {
            
            this.monedaMap = monedaMap;
            this.monedaService = monedaService;
            this.historialService = pHistorialService;
            this.HistorialMap = pHistorialMap;
            this.emailSender = emailSender;
            this.IMensajeMap = IMensajeMap;
            this.IUserRepository = IUserRepository;
            this.IMensajeReceptorRepository = IMensajeReceptorRepository;
            this.ImensajeService = ImensajeService;
            this.IMensajeReceptorMap = IMensajeReceptorMap;
            this.IBitacoraMap = IBitacoraMap;
        }

        [Route("Filtrado-Fecha")]
        public ActionResult BuscarByFecha(DateTime fecha)

        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


          
            IList<HistorialMonedaViewModel> historial = new List<HistorialMonedaViewModel>();

            historial = historialService.GetAllByFecha(fecha);
        
            ViewBag.fecha = fecha;
            ViewData["fechas"] = historial;
            ViewBag.estado = 1;
            return View(historial);
        }

        public ActionResult Guardar(int valor, double valorCompra, double valorVenta, String nombre, string simbolo, DateTime fecha)
        {
            if (valor == 2)
            {
                if (nombre != null)
                {
                    nombre = null;
                }
                else if (simbolo != null)
                {
                    simbolo = null;
                }

            }
            else if (valor == 3)
            {

                if (nombre != null)
                {
                    nombre = null;
                }
                else if (simbolo != null)
                {
                    simbolo = null;
                }
            }
            HistorialMonedaViewModel model = new HistorialMonedaViewModel
            {
                Codigo = valor,
                ValorCompra = valorCompra,
                ValorVenta = valorVenta,
                Nombre = nombre,
                Simbolo = simbolo,
                Fecha = fecha
            };

          TbSeHistorialMoneda m=  HistorialMap.Create(model);
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Agrego un nuevo historial",m.CodigoMoneda,"Monedas");
            return RedirectToAction(nameof(Index));

        }
        [HttpPost("Filtradas")]
        public ActionResult FiltroByFecha(int id, DateTime fecha1, DateTime fecha2)
        {
            ViewBag.estado = 1;
            ViewBag.id = id;
            IList<TbSeHistorialMoneda> historial = new List<TbSeHistorialMoneda>();
            if (fecha1 >= fecha2 || fecha1 == fecha2)
            {
                ViewBag.estado = 0;

            }
            historial = historialService.FiltrarByFecha(fecha1, fecha2);
            ViewData["historial"] = historial;

            return View();

        }

        [Route("Lista-Moneda")]
        public ActionResult Index()
        {
            IList<TbSeMoneda> monedas = new List<TbSeMoneda>();
            monedas = monedaService.GetAll();
            ViewData["s"] = monedas;
            if (monedas.Count == 0)
            {
                ViewBag.id = 1;
            }
            else
            {

                ViewBag.id = 0;
            }

            ViewBag.fecha = DateTime.Now;
            return View(monedas);
        }
        public void CrearNotificacion(string msj)
        {
    
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            TbSeMensaje notificacion = new TbSeMensaje(msj, "NO", int.Parse(id));
            List<TbSeMensajeReceptor> mensajeReceptor = new List<TbSeMensajeReceptor>();

            TbSeMensajeReceptor msjs = new TbSeMensajeReceptor();
            ViewData["usuarios"] = IUserRepository.GetAllByIdUsuario(74);
            foreach (var item in ViewData["usuarios"] as List<TbSeUsuario>)
            {

                mensajeReceptor.Add(this.IMensajeReceptorMap.Crear(int.Parse(id), Convert.ToInt32(item.Id)));


           //    EmailSender.emailSender(item.Correo, notificacion.Mensaje1, "Mensaje del Sistema Altiva Soluciones Seguridad");

            }

           IMensajeReceptorRepository.Crear(mensajeReceptor);
        }



        // GET: Monedas/Details/5
        [Route("Detalle-Historial")]
        public ActionResult Details(int id)
        {

          IList<TbSeHistorialMoneda> historial = new List<TbSeHistorialMoneda>();
            historial = historialService.GetHistorialById(id);
            ViewData["historial"] = historial;
            ViewBag.id = id;
            return View(historial);
        }
              

        public JsonResult insertarNuevaMoneda(int valor, double valorCompra, double valorVenta, String nombre, string simbolo, double valorCompra1, double valorVenta1, String nombre1, string simbolo1, double valorCompra2, double valorVenta2, String nombre2, string simbolo2, DateTime fecha)

        {


            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            IList<TbSeMoneda> historial = new List<TbSeMoneda>();
            TbSeMoneda moneda1 = new TbSeMoneda();
            moneda1.Codigo = 1;
            moneda1.Nombre = nombre;
            moneda1.ValorCompra = 1;
            moneda1.ValorVenta = 1;
            moneda1.Simbolo = simbolo;
            TbSeMoneda moneda2 = new TbSeMoneda();
            moneda2.Codigo = 2;
            moneda2.Nombre = "Dolar";
            moneda2.ValorCompra = valorCompra1;
            moneda2.ValorVenta = valorVenta1;
            moneda2.Simbolo = simbolo1;
            TbSeMoneda moneda3 = new TbSeMoneda();
            moneda3.Codigo = 3;
            moneda3.Nombre = "Euro";
            moneda3.ValorCompra = valorCompra2;
            moneda3.ValorVenta = valorVenta2;
            moneda3.Simbolo = simbolo2;
            historial.Add(moneda1);
            historial.Add(moneda2);
            historial.Add(moneda3);
          this.monedaService.CrearMoneda(historial);
            return Json(new { model = true });
        }

        [Route("Editar-Moneda/{valor}/{valorCompra}/{valorVenta}/{nombre}/{simbolo}")]
        public ActionResult Editar(int valor, double valorCompra,double valorVenta, string nombre,string simbolo)
           
        {
            var ids = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            if (valor == 2 )
            {
                this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Edito los valores de " + "Dolar" + "" + "Compra" + "" + valorCompra + "" + "Venta" + "" + valorVenta + " ", 2, "Monedas");

                if ( nombre != null)
                {
                    nombre = null;
                }else if (simbolo != null)
                {
                    nombre = null;
                }

            }
            else if (valor == 3)
            {
                this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Edito los valores de " + "Euro" + "" + "Compra" + "" + valorCompra + "" + "Venta" + "" + valorVenta + " ", 3, "Monedas");

                if (nombre != null)
                {
                    nombre = null;
                }
                else if (simbolo != null)
                {
                    nombre = null;
                }
            }
            else
            {
                this.IBitacoraMap.CrearBitacora(Convert.ToInt32(ids), "Edito los valores de " + simbolo + "" + "Compra" + "" + valorCompra + "" + "Venta" + "" + valorVenta + " ", 1, "Monedas");

            }
            MonedaViewModel model = new MonedaViewModel
            {
                Codigo = valor,
                ValorCompra = valorCompra,
                ValorVenta = valorVenta,
                Nombre =nombre,
                Simbolo=simbolo
            };
          TbSeMoneda m =  monedaMap.Update(model);
            CrearNotificacion("Has editado una moneda");
        
                return RedirectToAction(nameof(Index));
           
               
        }

       

        [Route("GetTipoCambio")]
        public ActionResult GetTipoCambio(int id)
        {
            if (id !=0) {
                var model = new TbSeMoneda();
                model = monedaMap.getTipoDeCambio(id);
                if (model != null) {
                    return Json(new { valorCompra = model.ValorCompra, valorVenta = model.ValorVenta });
                }
            }

            return Json(new { });
        }

        
       

    }
}