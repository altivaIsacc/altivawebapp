using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Mappers;
namespace AltivaWebApp.Controllers
{

   
    
    public class CamposPersonalizadosController : Controller
    {
        //variable service
        public ICamposPersonalizadosService pCamposPersonalizados;

        public IContactoMap IcontactoMap;
        IListaDesplegableMapper map;
        //contructor
        public CamposPersonalizadosController(IContactoMap IcontactoMap,ICamposPersonalizadosService pCamposPersonalizados, IListaDesplegableMapper map)
        {
            this.pCamposPersonalizados = pCamposPersonalizados;
            this.IcontactoMap = IcontactoMap;
            this.map = map;
        }

        public JsonResult TraerCamposPersonalizados()
        {
            IList<TbCrCamposPersonalizados> campos = new List<TbCrCamposPersonalizados>();
            campos = this.pCamposPersonalizados.GetCampos();
            return new JsonResult(campos);

        }
        // GET: CamposPersonalizados
        public ActionResult Index()
        {
            IList<TbCrCamposPersonalizados> campos = new List<TbCrCamposPersonalizados>();
         campos =   this.pCamposPersonalizados.GetAll();
           return View(campos);
           // return View(campos);
        }

        // GET: CamposPersonalizados/Details/5
        public ActionResult Details(int id)
        {


            TbCrCamposPersonalizados contactoMap = new TbCrCamposPersonalizados();
            contactoMap = this.pCamposPersonalizados.getById(id);
            return View(contactoMap);
           
        }
        public ActionResult CrearCamposPersonalizados(CamposPersonalizadosViewModelSingle domain2)
        {
             
            return PartialView("_CrearEditarCampos",domain2);
        }
        // GET: CamposPersonalizados/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CrearNuevoCamposPersonalizados(CamposPersonalizadosViewModelSingle domain)
        {
            List<TbCrCamposPersonalizados> ListaCampos = new List<TbCrCamposPersonalizados>();
          
            try
            {
                TbCrCamposPersonalizados vd = new TbCrCamposPersonalizados();
                vd = this.map.Save(domain);
                return new JsonResult(vd);
         
            }
            catch
            {
                return new JsonResult(1);
            }
        }

        // GET: CamposPersonalizados/Edit/5
        public ActionResult Edit(int id)
        {
            TbCrCamposPersonalizados contactoMap = new TbCrCamposPersonalizados();
            contactoMap = this.pCamposPersonalizados.getById(id);
            return View(contactoMap);
        }

        // POST: CamposPersonalizados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( int id,TbCrCamposPersonalizados collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                TbCrCamposPersonalizados contactoMap = new TbCrCamposPersonalizados();
                contactoMap = this.pCamposPersonalizados.Edit(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       public ActionResult Delete(int id)
        {
            TbCrCamposPersonalizados cp = new TbCrCamposPersonalizados();
            cp = this.IcontactoMap.Delete(id);

            return new JsonResult(1);

        }

    }
}