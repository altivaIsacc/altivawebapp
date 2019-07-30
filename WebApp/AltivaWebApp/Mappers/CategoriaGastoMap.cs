using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class CategoriaGastoMap: ICategoriaGastoMap
    {
        private readonly ICategoriaGastoService service;
        public CategoriaGastoMap(ICategoriaGastoService service)
        {
            this.service = service;
        }


        public TbCpCategoriaGasto Create(CategoriaGastoVIewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbCpCategoriaGasto Update(CategoriaGastoVIewModel viewModel)
        {
            return service.Update(ViewModelToDomain(viewModel));
        }

        public TbCpCategoriaGasto ViewModelToDomain(CategoriaGastoVIewModel viewModel)
        {
            return new TbCpCategoriaGasto {
                Estado = viewModel.Estado,
                FechaCreacion = viewModel.FechaCreacion,
                Id = viewModel.Id,
                IdUsuario = viewModel.IdUsuario,
                Nombre = viewModel.Nombre,
                Tipo = viewModel.Tipo
            };
        }


        public CategoriaGastoVIewModel DomainToViewModel(TbCpCategoriaGasto domain)
        {
            return new CategoriaGastoVIewModel
            {
                Estado =(bool) domain.Estado,
                FechaCreacion = domain.FechaCreacion,
                Id = domain.Id,
                IdUsuario = domain.IdUsuario,
                Nombre = domain.Nombre,
                Tipo = (bool) domain.Tipo
            };
        }


    }
}
