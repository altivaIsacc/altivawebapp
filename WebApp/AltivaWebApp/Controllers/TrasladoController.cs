﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AltivaWebApp.Helpers;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AltivaWebApp.Controllers
{

    [Route("{culture}/Traslados")]
    public class TrasladoController : Controller
    {

        private readonly ITrasladoService trasladoService;
        private readonly ITrasladoMap trasladoMap;

        private readonly IUserService userService;

        private readonly ITrasladoInventarioService trasladoInventarioService;
        private readonly ITrasladoInventarioMap trasladoInventarioMap;


        //constructor
        public TrasladoController(ITrasladoService _trasladoService, ITrasladoMap _trasladoMap, IUserService _userService, ITrasladoInventarioService _trasladoInventarioService, ITrasladoInventarioMap _trasladoInventarioMap)
        {
            this.trasladoService = _trasladoService;
            this.trasladoMap = _trasladoMap;
            this.userService = _userService;
            this.trasladoInventarioService = _trasladoInventarioService;
            this.trasladoInventarioMap = _trasladoInventarioMap;

        }

        [Route("Lista-traslados")]
        public ActionResult ListarTraslados()
        {
            return View();
        }

        [HttpGet("Listar-Traslados")]
        public IActionResult _ListarTraslados()
        {
            return PartialView("_ListarTraslados");
        }

        [HttpGet("Crear-Traslado")]
        public IActionResult _CrearTraslado()
        {

            return PartialView("_CrearEditarTraslado", new TrasladoViewModel());
        }

        [HttpGet("Editar-Traslado/{id}")]
        public IActionResult _EditarTraslado(long id)
        {
            return PartialView("_CrearEditarTraslado", trasladoMap.DomainToViewModel(trasladoService.GetTrasladoById(id)));
        }



        [HttpGet("Get-Traslados")]
        public ActionResult GetTraslados()
        {
            try
            {
                var traslado = trasladoService.GetAllTraslado();//revisar obtiene todos los usuarios

                foreach (var item in traslado)
                {
                    item.IdBodegaDestinoNavigation.TbPrTrasladoIdBodegaDestinoNavigation = null;
                    item.IdBodegaOrigenNavigation.TbPrTrasladoIdBodegaOrigenNavigation = null;
                }

                return Ok(traslado);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }





        [HttpPost("CrearEditar-Traslado")]
        public ActionResult CrearEditarTraslado(TrasladoViewModel traslado, IList<TrasladoInventarioViewModel> inventarioTraslado)
        {

         
            try
            {
           
                if (traslado.IdTraslado != 0)
                {
                    traslado.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    //traslado = trasladoMap.Update(viewModel);
                }
                else
                {
                    traslado.TrasladoInventarioDetalle = inventarioTraslado;
                    traslado.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    traslado.FechaCreacion = DateTime.Now;
                    traslado.Anulado = false;//cambiar luego
                                             
                    var respTraslado = trasladoMap.Create(traslado);

                    foreach (var item in inventarioTraslado)
                    {
                        item.IdTraslado = respTraslado.IdTraslado;
                    }

                    respTraslado.TbPrTrasladoInventario = trasladoMap.CreateOrUpdateAI(inventarioTraslado);
                  
                }
                return Json(new { success = true });
            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpGet("Get-TrasladoInventario/{id}")]
        public ActionResult GetTrasladoInventario(long id)
        {
            try
            {
             
                var trasladoInventario = trasladoInventarioService.GetTrasladoInventarioById(id);
                
                return Ok(trasladoInventario);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("Get-Traslado/{id}")]
        public ActionResult GetTraslado(long id)
        {
            try
            {
                var traslado = trasladoService.GetTrasladoById(id);
               
                //foreach (var item in traslado.TbPrTrasladoInventario)
                //{
                //    item.IdInventarioNavigation = null;
                //    item.IdTrasladoNavigation = null;
                //}
                return Ok(traslado);
            }
            catch
            {
                return BadRequest();
            }
        }













    }
}