using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class GEMap: IGEMap
    {
        private IGEService service;
        private readonly IHostingEnvironment hostingEnvironment;

        public GEMap(IGEService service, IHostingEnvironment hostingEnvironment)
        {
            this.service = service;
            this.hostingEnvironment = hostingEnvironment;
        }

        public TbGeEmpresa Create(EmpresaViewModel model)
        {
            return service.Save(ViewModelToDomainCrear(model));
        }

        public TbGeEmpresa Update(EmpresaViewModel model)
        {
            return service.Update(ViewModelToDomainEditar(model));
        }       

        public TbGeEmpresa ViewModelToDomainEditar(EmpresaViewModel model)
        {

            var domain = service.GetEmpresaById(model.Id);

            domain.Bd = model.Bd;

            if(domain.CedJuridica != model.CedJuridica)
            {
                if(service.GetByCedula(model.CedJuridica) == null)
                    domain.CedJuridica = model.CedJuridica;
            }            
            domain.Correo = model.Correo;
            domain.Direccion = model.Direccion;
            domain.Estado = model.Estado;            
            domain.FechaMod = DateTime.Now;
            domain.Nombre = model.Nombre;
            domain.Telefono1 = model.Telefono1;
            domain.Telefono2 = model.Telefono2;
            //domain.IdGrupoEmpresarial = model.Id_GE;
            if (model.Foto != null)
            {
                var savePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                domain.Foto = FotosService.SubirFotoEmpresa(model.Foto,savePath);
            }

            return domain;
        }

        public TbGeEmpresa ViewModelToDomainCrear(EmpresaViewModel model)
        {
            var savePath = System.IO.Path.Combine(Startup.entorno.WebRootPath, "Files");
            var domain = new TbGeEmpresa
            {
                Bd = model.Bd,
                CedJuridica = model.CedJuridica,
                Correo = model.Correo,
                Direccion = model.Direccion,
                Estado = true,
                FechaCreacion = DateTime.Now,
                FechaMod = DateTime.Now,
                Nombre = model.Nombre,
                Telefono1 = model.Telefono1,
                Telefono2 = model.Telefono2,
                IdGrupoEmpresarial = model.Id_GE             
            };

            if (model.Foto != null)
                domain.Foto = FotosService.SubirFotoEmpresa(model.Foto, savePath);
            else
                domain.Foto = "";


            return domain;
        }

        public EmpresaViewModel DomainToViewModel(TbGeEmpresa domain)
        {
            var model = new EmpresaViewModel
            {
                Bd = domain.Bd,
                CedJuridica = domain.CedJuridica,
                Correo = domain.Correo,
                Direccion = domain.Direccion,
                Estado = domain.Estado,
                Foto = null,
                Id_GE = (int)domain.IdGrupoEmpresarial,
                Nombre = domain.Nombre,
                Telefono1 = domain.Telefono1,
                Telefono2 = domain.Telefono2
            };

            return model;

        }


    }
}
