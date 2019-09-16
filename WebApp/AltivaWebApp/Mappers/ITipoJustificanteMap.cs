using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface ITipoJustificanteMap
    {
        TbFaTipoJustificante Create(TipoJustificanteViewModel viewModel);
        TbFaTipoJustificante Update(TipoJustificanteViewModel viewModel);
        TbFaTipoJustificante ViewModelToDomain(TipoJustificanteViewModel viewModel);
        TbFaTipoJustificante ViewModelToDomainEditar(TipoJustificanteViewModel viewModel);
        TipoJustificanteViewModel DomainToVIewModel(TbFaTipoJustificante domain);

    }
}
