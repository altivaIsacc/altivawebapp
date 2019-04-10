using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class ModuloMap : IModuloMap
    {
        private IModuloService service;

        public ModuloMap(IModuloService service)
        {
            this.service = service;
        }

        public TbSeModulo Update(ModuloViewModel model)
        {
            return service.Update(ViewModelToDomain(model));
        }

        public ModuloViewModel DomainToViewModelSingle(TbSeModulo domain)
        {
            ModuloViewModel model = new ModuloViewModel
            {
                Nombre = domain.NombreExterno,
                Descripcion = domain.Descripcion,
                Grupo = domain.Grupos,
                Nota1 = domain.NotaOpcion1,
                Nota2 = domain.NotaOpcion2,
                Id = (int)domain.Id
            };

            return model;
        }

        public TbSeModulo ViewModelToDomain(ModuloViewModel officeViewModel)
        {
            var domain = service.GetModuloById(officeViewModel.Id);

            domain.NombreExterno = officeViewModel.Nombre;
            domain.Descripcion = officeViewModel.Descripcion;
            domain.NotaOpcion1 = officeViewModel.Nota1;
            domain.NotaOpcion2 = officeViewModel.Nota2;

            return domain;
        }

    }
}