using System;
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
using FastReport.Web;
using System.Globalization;
using System.Data.SqlClient;
using AltivaWebApp.Context;
using Microsoft.EntityFrameworkCore;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Controllers
{
    [Route("{culture}/ContactoVisitas")]
    public class ContactoVisitaController : Controller
    {

        private readonly IContactoVisitaService contactoVisitaService;
        private readonly IContactoVisitaMap contactoVisitaMap;
        private readonly IUserService userService;
        private readonly IVisitaTipoService visitaTipoService;
        private readonly IVisitaTipoMap visitaTipoMap;
      
        EmpresasContext context;

        //constructor
        public ContactoVisitaController(IContactoVisitaService _contactoVisitaService, IContactoVisitaMap _contactoVisitaMap, IUserService _userService, IVisitaTipoService _visitaTipoService, IVisitaTipoMap _visitaTipoMap, EmpresasContext bd)
        {
            this.contactoVisitaService = _contactoVisitaService;
            this.contactoVisitaMap = _contactoVisitaMap;
            this.userService = _userService;
            this.visitaTipoService = _visitaTipoService;
            this.visitaTipoMap = _visitaTipoMap;          
            context = bd;
        }

        [Route("Listar-contactoVisita")]
        public ActionResult ListarContactoVisita()
        {
            return View();
        }

        ////get auxiliares

        [HttpGet("Get-ContactoVisita")]
        public ActionResult GetContactoVisita()
        {
            try
            {
                var contactoVisita = contactoVisitaService.GetAllContactoVisita();//obtiene todos los ususarios

                foreach (var item in contactoVisita)
                {
                    item.IdVisitaTipoNavigation.TbCrContactoVisita = null;
                
                }

                return Ok(contactoVisita);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return BadRequest();
            }

        }
















    }
}