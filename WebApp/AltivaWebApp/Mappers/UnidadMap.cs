using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class UnidadMap: IUnidadMap
    {
        readonly IUnidadService service;
        public UnidadMap(IUnidadService service)
        {
            this.service = service;
        }

        public TbPrUnidadMedida Create(UnidadViewModel viewModel)
        {
            return service.Save(ViewModelToDomainNuevo(viewModel));
        }

        public TbPrUnidadMedida Update(int id, UnidadViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(id, viewModel));
        }

        public TbPrUnidadMedida ViewModelToDomainNuevo(UnidadViewModel viewModel)
        {
            return new TbPrUnidadMedida
            {
                Abreviatura = viewModel.Abreviatura,
                FechaCreacion = DateTime.Now,
                IdUsuario = viewModel.IdUsuario,
                Nombre = viewModel.Nombre
            };
        }

        public TbPrUnidadMedida ViewModelToDomainEditar(int id, UnidadViewModel viewModel)
        {
            var unidad = service.GetUnidadById(id);
            unidad.Abreviatura = viewModel.Abreviatura;
            unidad.Nombre = viewModel.Nombre;

            return unidad;
        }

        public UnidadViewModel DomainToViewModel(TbPrUnidadMedida domain)
        {
            return new UnidadViewModel
            {
                Id =(int) domain.Id,
                Abreviatura = domain.Abreviatura,
                Nombre = domain.Nombre,
                IdUsuario = (int)domain.IdUsuario
            };
        }


    }
}
