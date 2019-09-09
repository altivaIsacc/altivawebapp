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


    [Route("{culture}/Campos-Personalizados")]
    public class CamposPersonalizadosController : Controller
    {
        //variable service
        private readonly ICamposPersonalizadosService cpService;
        private readonly IContactoMap contactoMap;
        private readonly IListaDesplegableMapper listaDesMap;
        private readonly IListaDesplegableService listaService;
        //contructor
        public CamposPersonalizadosController(IListaDesplegableService listaService,IContactoMap IcontactoMap, ICamposPersonalizadosService pCamposPersonalizados, IListaDesplegableMapper map)
        {
            this.cpService = pCamposPersonalizados;
            this.contactoMap = IcontactoMap;
            this.listaDesMap = map;
            this.listaService = listaService;
        }


        // GET: CamposPersonalizados
        [Route("Lista")]
        public ActionResult CamposPersonalizados()
        {
            return View();
        }

        [HttpGet("_ListarCamposPersonalizados")]
        public IActionResult _ListarCamposPersonalizados()
        {
            return PartialView(cpService.GetCampos());
        }

        [HttpGet("Nuevo-CP")]
        public IActionResult NuevoCP()
        {
            return PartialView("_CrearEditarCampos", new CamposPersonalizadosViewModel { Estado = "Activo" });
        }

        [HttpGet("Editar-CP/{id}")]
        public IActionResult EditarCP(int id)
        {
            return PartialView("_CrearEditarCampos", contactoMap.DomainToViewModelCP(cpService.getById(id)));
        }

        [HttpPost("CrearEditarCampo")]
        public IActionResult CrearEditarCampo(CamposPersonalizadosViewModel viewModel, IList<ListaViewModel> lista, IList<long> optListaEliminados )
        {
            try
            {
                var campo = new TbCrCamposPersonalizados();

                var existeCampo = cpService.GetCPPorNombre(viewModel.Nombre);
                if(viewModel.Id != 0)
                {
                    if (existeCampo != null && existeCampo.Id != viewModel.Id)
                        return Json(new { success = false });

                    campo = contactoMap.UpdateCP(viewModel);
                    if(viewModel.Tipo == "lista" && lista.Count() != 0)
                    {
                        listaDesMap.SaveOrUpdate(lista);
                    }

                    if(optListaEliminados.Count() > 0)
                    {
                        listaService.DeleteRange(optListaEliminados);
                    }

                }
                else
                {
                    if (existeCampo != null)
                        return Json(new { success = false });

                    campo = contactoMap.SaveCP(viewModel);

                    

                    if (viewModel.Tipo == "lista" && lista.Count() != 0)
                    {
                        foreach (var item in lista)
                        {
                            item.IdCamposPersonalizados =(int) campo.Id;
                        }
                        listaDesMap.SaveOrUpdate(lista);
                    }
                }
                campo.TbCrListaDesplegables = null;

                return Json( new { success = true, campo = campo });
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        [HttpGet("GetValorLista/{id}")]
        public IActionResult GetValorLista(int id)
        {
            try
            {
                return Ok(listaService.GetListaByIdCampo(id));
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


    }
}