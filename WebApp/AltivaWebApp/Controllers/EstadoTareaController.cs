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

    [Route("{culture}/EstadoTarea")]
    public class EstadoTareaController : Controller
    {
        public IEstadoTareaService IEstadoService;

        //variable mapper
        public IEstadoTareaMapper IEstadoMapper;

        public EstadoTareaController(IEstadoTareaService IEstadoService, IEstadoTareaMapper IEstadoMapper)
        {
            this.IEstadoService = IEstadoService;
            this.IEstadoMapper = IEstadoMapper;
        }




        [HttpGet("ListarEstados")]
        public JsonResult GetEstados()
        {
            IList<TbFdTareaEstado> te = new List<TbFdTareaEstado>();

            te = this.IEstadoService.GetAll();
            return new JsonResult(te);
        }





        [HttpGet("Lisar-Estados")]
        // GET: EstadoTarea
        public ActionResult ListarEstados()
        {
            return View();
        }




        [HttpGet("ListarEstadosTareas/{inactivo?}")]
        public IActionResult ListarEstadosTareas(string inactivo)
        {
            IList<TbFdTareaEstado> te = new List<TbFdTareaEstado>();
            IList<TbFdTareaEstado> tpL = new List<TbFdTareaEstado>();

            te = this.IEstadoService.GetAll();

            if (inactivo == null)
            {
                ViewBag.estado = 1;
                foreach (var item in te)
                {
                    if (item.Activo == true)
                    {
                        tpL.Add(item);
                    }
                }
            }
            else
            {
                ViewBag.estado = 2;
                foreach (var item in te)
                {
                    if (item.Activo == false)
                    {
                        tpL.Add(item);
                    }
                }
            }
            return PartialView("_ListarEstados", tpL);
        }



        [HttpGet("CrearEstadoVista")]
        [HttpGet]
        public IActionResult CrearEstadoVista()
        {
            var EstadoTarea = new TbFdTareaEstado();

            return PartialView("_CrearEditarEstados", EstadoTarea);
        }




        [HttpGet("EditarEstadoVista/{idEstado?}")]
        [HttpGet]
        public IActionResult EditarEstadoVista(int idEstado)
        {
            var EstadoTarea = new TbFdTareaEstado();
            EstadoTarea = this.IEstadoService.GetById(idEstado);

            return PartialView("_CrearEditarEstados", EstadoTarea);
        }



        [HttpPost("EditarEstado")]
        [HttpPost]
        public IActionResult EditarEstado(EstadoTareaViewModel domain)
        {
            TbFdTareaEstado estadoTarea = new TbFdTareaEstado();
            TbFdTareaEstado titulo = new TbFdTareaEstado();
            TbFdTareaEstado color = new TbFdTareaEstado();
            TbFdTareaEstado porDefecto = new TbFdTareaEstado();
            TbFdTareaEstado esInicial = new TbFdTareaEstado();
            TbFdTareaEstado esFinal = new TbFdTareaEstado();
            titulo = this.IEstadoService.GetTitulo(domain.Titulo);
            color = this.IEstadoService.GetColor(domain.Color);
            porDefecto = this.IEstadoService.GetDefecto(true);
            esInicial = this.IEstadoService.GetInicial(true);
            esFinal = this.IEstadoService.GetFinal(true);

            if (this.IEstadoService.GetByTitulo(domain.Titulo))
            {
                if (titulo.Id != domain.Id)
                {
                    return Json(new { titulo = true });
                }
            }

            if (this.IEstadoService.GetByColor(domain.Color))
            {
                if (color.Id != domain.Id)
                {
                    return Json(new { color = true });

                }
            }

            if (this.IEstadoService.GetByDefecto(domain.EsDefecto) == true)
            {
                if (domain.EsDefecto == true)
                {
                    if (porDefecto.Id != domain.Id)
                    {
                        return Json(new { defecto = true });
                    }
                }
            }

            if (this.IEstadoService.GetByEsInicial(domain.EsInicial) == true)
            {
                if (domain.EsInicial == true)
                {
                    if (esInicial.Id != domain.Id)
                    {
                        return Json(new { inicial = true });
                    }
                }
            }

            if (this.IEstadoService.GetByEsFinal(domain.EsFinal) == true)
            {
                if (domain.EsFinal == true)
                {
                    if (esFinal.Id != domain.Id)
                    {
                        return Json(new { final = true });
                    }
                }
            }



            estadoTarea = this.IEstadoMapper.Update(domain);


            return Json(new { titulo = false, color = false, defecto = false, inicial = false, final = false});
        }




        [HttpPost("Inactivar")]
        [HttpPost]
        public ActionResult Inactivar(EstadoTareaViewModel domain)
        {
            try
            {

                var tareaEstado = new TbFdTareaEstado();
                    tareaEstado = this.IEstadoMapper.Update(domain);

                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
                //return BadRequest();
            }

        }







        [HttpPost("CrearEstado")]
        public JsonResult CrearEstado(EstadoTareaViewModel domain)
        {
            try
            {

                if (this.IEstadoService.GetByTitulo(domain.Titulo))
                {
                    return Json(new { titulo = true });
                }


                else if (this.IEstadoService.GetByColor(domain.Color))
                {
                    return Json(new { color = true });
                }



                if (domain.EsInicial != false)
                {
                    if (this.IEstadoService.GetByEsInicial(domain.EsInicial) == true)
                    {
                        return Json(new { inicial = true });
                    }                
                }

                if (domain.EsFinal != false)
                {
                    if (this.IEstadoService.GetByEsFinal(domain.EsFinal) == true)
                    {
                        return Json(new { final = true });
                    }
                }


                if (domain.EsDefecto != false)
                {

                    if (this.IEstadoService.GetByDefecto(domain.EsDefecto) == true)
                    {
                        return Json(new { defecto = true });
                    }
                    else
                    {
                        var estadoTarea = this.IEstadoMapper.Save(domain);
                    }
                }
                else
                    {
                    var estadoTarea = this.IEstadoMapper.Save(domain);
                    }


               
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

            return Json(new { titulo = false, color = false, defecto = false, inicial = false });
        }




        [HttpGet("Eliminar-Estado")]
        public IActionResult Delete(int idEstado)
        {

            try
            {
                TbFdTareaEstado te = new TbFdTareaEstado();
                te = this.IEstadoService.GetById(idEstado);
                bool flag = this.IEstadoService.Delete(te);
                return Json(new { success = flag });


            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return new JsonResult(false);
            }

           
        }




    }
}