using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.Repositories;
using AltivaWebApp.Mappers;
using AltivaWebApp.ViewModels;
using System.Security.Claims;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/HistorialMonedaController")]
    public class HistorialMonedaController : Controller
    {
        IHistorialMonedaService HistorialService;
        IHistorialMonedaMap HistorialMap;
        public IHistorialMonedaRepository HistorialRepo;
        public EmailSender email;
        public HistorialMonedaController(EmailSender email, IHistorialMonedaService pHistorialService, IHistorialMonedaMap pHistorialMap, IHistorialMonedaRepository pHistorialRepo)
        {
            this.HistorialService = pHistorialService;
            this.HistorialMap = pHistorialMap;
            this.HistorialRepo = pHistorialRepo;
            this.email = email;
        }
        // GET: HistorialMoneda
        [HttpGet("Index")]
        public ActionResult Index()
        {

            DateTime orderDate = DateTime.Now.AddDays(-1);
            IList<HistorialMonedaViewModel> historial = new List<HistorialMonedaViewModel>();

            historial = HistorialService.GetAllByFecha(orderDate);
            return View(historial);
        }
        [HttpPost("EditarHistorialMoneda")]
        public JsonResult EditarHistorialMoneda(List<EditarHistorialMonedaViewModel> domain)
        {
            List<TbSeHistorialMoneda> historial = new List<TbSeHistorialMoneda>();
           this.HistorialMap.ModificarHistorialMoneda(domain);

            return new JsonResult(true);
        }
      //  [HttpGet("GuardarHistorial/{valor}/{valorCompra}/{valorVenta}/{nombre}/{simbolo}/{valorCompra1}/{valorVenta1}/{nombre1}/{simbolo1/{valorCompra2}/{valorVenta2}/{nombre2}/{simbolo2}/{fecha}")]
        public IActionResult GuardarHistorial(int valor, double valorCompra, double valorVenta, string nombre, string simbolo, double valorCompra1, double valorVenta1, string nombre1, string simbolo1, double valorCompra2, double valorVenta2, string nombre2, string simbolo2, string fecha)
        {

            DateTime fe = DateTime.Parse(fecha);
            Console.Write(fe);
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            IList<TbSeHistorialMoneda> historial = new List<TbSeHistorialMoneda>();
            TbSeHistorialMoneda moneda1 = new TbSeHistorialMoneda();
            moneda1.CodigoMoneda = 1;
            moneda1.Fecha = fe;
            moneda1.ValorCompra = 1;
            moneda1.ValorVenta = 1;
            TbSeHistorialMoneda moneda2 = new TbSeHistorialMoneda();
            moneda2.CodigoMoneda = 2;
            moneda2.Fecha = fe;
            moneda2.IdUsuario = int.Parse(id);
            moneda2.ValorCompra = valorCompra1;
            moneda2.ValorVenta = valorVenta1;
            TbSeHistorialMoneda moneda3 = new TbSeHistorialMoneda();
            moneda3.CodigoMoneda = 3;
            moneda3.Fecha = fe;
            moneda3.IdUsuario = int.Parse(id);
            moneda3.ValorCompra = valorCompra2;
            moneda3.ValorVenta = valorVenta2;
            historial.Add(moneda1);
            historial.Add(moneda2);
            historial.Add(moneda3);

            this.HistorialRepo.GuardarHistorial(historial);
            Notificar("Se ha ingresado un nuevo historial");
            return Json(new { success = 1 });
        }
        public void GuardarDiario()
        {
            DateTime fecha = new DateTime();

            IList<TbSeHistorialMoneda> historial = new List<TbSeHistorialMoneda>();
            fecha = DateTime.Today.AddDays(-1);
            historial = HistorialService.GetByDate(fecha.AddDays(-1));
            if (HistorialService.Guardar(historial) == 1)
            {
                Console.WriteLine("exitoso");
            }
            else
            {
                Console.WriteLine("error");
            }

        }
        // GET: HistorialMoneda/Details/5
        [HttpGet("Details/{id?}")]
        public IActionResult Details(int id)
        {
            return View();
        }
        [HttpGet("BuscarByFecha/{fecha}")]
        public IActionResult BuscarByFecha(DateTime fecha)
        {
            IList<HistorialMonedaViewModel> historial = new List<HistorialMonedaViewModel>();

            historial = HistorialService.GetAllByFecha(fecha);
            return PartialView("~/Views/HistorialMoneda/Index.cshmtl", historial);


        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        
        public void Notificar(string mensaje)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            //email.insertarNotificacion(int.Parse(id), mensaje);

        }
        [HttpGet("Guardar/{valor?}/{Compra?}/{Venta?}/{nombres?}/{simbolos?}/{fechas?}")]
        public IActionResult Guardar(int valor, double Compra, double Venta, String nombres, string simbolos, String fechas)
        {
            DateTime enteredDate = DateTime.Parse(String.Format("{0:d/M/yyyyTHH:mm:ss}", fechas));

            if (valor == 2)
            {
                if (nombres != null)
                {
                    nombres = null;
                }
                else if (simbolos != null)
                {
                    simbolos = null;
                }

            }
            else if (valor == 3)
            {

                if (nombres != null)
                {
                    nombres = null;
                }
                else if (simbolos != null)
                {
                    simbolos = null;
                }
            }
            HistorialMonedaViewModel model = new HistorialMonedaViewModel
            {
                Codigo = valor,
                ValorCompra = Compra,
                ValorVenta = Venta,
                Nombre = nombres,
                Simbolo = simbolos,
                Fecha = enteredDate
            };

            HistorialMap.Create(model);
            Notificar("Se ha ingresado un nuevo historial");
            return RedirectToAction(nameof(Index));

        }
    
     

       


    }
}