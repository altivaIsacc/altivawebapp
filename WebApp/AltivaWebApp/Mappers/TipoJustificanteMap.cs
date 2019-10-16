using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class TipoJustificanteMap: ITipoJustificanteMap
    {
        private readonly ITipoJustificanteService service;

        public TipoJustificanteMap(ITipoJustificanteService service)
        {
            this.service = service;
        }
        public TbFaTipoJustificante Create(TipoJustificanteViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbFaTipoJustificante Update(TipoJustificanteViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEditar(viewModel));
        }


        public TbFaTipoJustificante ViewModelToDomain(TipoJustificanteViewModel viewModel)
        {
            return new TbFaTipoJustificante
            {              
                Nombre = viewModel.Nombre,
                Estado = viewModel.Estado,
                Cxp = viewModel.Cxp,
                Cxc = viewModel.Cxc

            };
        }

        public TbFaTipoJustificante ViewModelToDomainEditar(TipoJustificanteViewModel viewModel)
        {
            var domain = service.GetTipoJustificanteById(viewModel.IdTipoJustificante);

            domain.Nombre = viewModel.Nombre;
            domain.Estado = viewModel.Estado;
            domain.Cxp = viewModel.Cxp;
            domain.Cxc = viewModel.Cxc;


            return domain;
        }

        public TipoJustificanteViewModel DomainToVIewModel(TbFaTipoJustificante domain)
        {
            return new TipoJustificanteViewModel
            {
                IdTipoJustificante = domain.IdTipoJustificante,
                Nombre = domain.Nombre,
                Estado = domain.Estado,
                Cxp = domain.Cxp,
                Cxc = domain.Cxc
            };
        }

    }
}
