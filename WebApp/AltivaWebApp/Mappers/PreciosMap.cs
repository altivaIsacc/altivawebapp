using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AltivaWebApp.Mappers
{
    public class PreciosMap: IPreciosMap
    {
        private readonly IPreciosService service;

        public PreciosMap(IPreciosService service)
        {
            this.service = service;
        }
        public TbPrPrecios Create(PreciosViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbPrPrecios Update(PreciosViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }


        public TbPrPrecios ViewModelToDomain(PreciosViewModel viewModel)
        {
            return new TbPrPrecios
            {
                Anulado = false,
                Descripcion = viewModel.Descripcion,
                Nombre = viewModel.Nombre,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                IdUsuario = viewModel.IdUsuario
            };
        }

        public TbPrPrecios ViewModelToDomainEditar(PreciosViewModel viewModel)
        {
            var domain = service.GetPreciosById(viewModel.Id);

            domain.Descripcion = viewModel.Descripcion;
            domain.Nombre = viewModel.Nombre;
           

            return domain;
        }

        public PreciosViewModel DomainToVIewModel(TbPrPrecios domain)
        {
            return new PreciosViewModel
            {
                Id = domain.Id,
                Descripcion = domain.Descripcion,
                Nombre = domain.Nombre,
                Fecha = domain.Fecha,
                IdUsuario = (int)domain.IdUsuario
            };
        }
    }
}
