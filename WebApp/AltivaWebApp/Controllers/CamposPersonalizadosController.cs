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
        //contructor
        public CamposPersonalizadosController(IContactoMap IcontactoMap,ICamposPersonalizadosService pCamposPersonalizados)
        {
            this.pCamposPersonalizados = pCamposPersonalizados;
            this.IcontactoMap = IcontactoMap;
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

        // GET: CamposPersonalizados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CamposPersonalizados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CamposPersonalizadosViewModel collection)
        {
            List<TbCrCamposPersonalizados> ListaCampos = new List<TbCrCamposPersonalizados>();
          
            try
            {
            
                for (int i = 0; i < collection.Nombre.Length;i++)
                {
                            TbCrCamposPersonalizados camp = new TbCrCamposPersonalizados();
              
               
             

                        camp.Nombre = collection.Nombre[i];
                        camp.Tipo = collection.Tipo[i];

                    ListaCampos.Add(camp);
                }

                pCamposPersonalizados.CrearCamposPersonalizados(ListaCampos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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

            return RedirectToAction("Index");

        }

    }
}