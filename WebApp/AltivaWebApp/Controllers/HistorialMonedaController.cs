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
        public ActionResult Index()
        {

            DateTime orderDate = DateTime.Now.AddDays(-1);
            IList<HistorialMonedaViewModel> historial = new List<HistorialMonedaViewModel>();

            historial = HistorialService.GetAllByFecha(orderDate);
            return View(historial);
        }
        [HttpPost]
        public JsonResult EditarHistorialMoneda(List<EditarHistorialMonedaViewModel> domain)
        {
            List<TbSeHistorialMoneda> historial = new List<TbSeHistorialMoneda>();
           this.HistorialMap.ModificarHistorialMoneda(domain);

            return new JsonResult(true);
        }
        public JsonResult GuardarHistorial(int valor, double valorCompra, double valorVenta, String nombre, string simbolo, double valorCompra1, double valorVenta1, String nombre1, string simbolo1, double valorCompra2, double valorVenta2, String nombre2, string simbolo2, string fecha)
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
            notificar("Se ha ingresado un nuevo historial");
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
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult BuscarByFecha(DateTime fecha)
        {
            IList<HistorialMonedaViewModel> historial = new List<HistorialMonedaViewModel>();

            historial = HistorialService.GetAllByFecha(fecha);
            return PartialView("~/Views/HistorialMoneda/Index.cshmtl", historial);


        }
        // GET: HistorialMoneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialMoneda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public void notificar(string mensaje)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            //email.insertarNotificacion(int.Parse(id), mensaje);

        }
        public ActionResult Guardar(int valor, double Compra, double Venta, String nombres, string simbolos, String fechas)
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
            notificar("Se ha ingresado un nuevo historial");
            return RedirectToAction(nameof(Index));

        }
        // GET: HistorialMoneda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorialMoneda/Edit/5
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

        // GET: HistorialMoneda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistorialMoneda/Delete/5
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