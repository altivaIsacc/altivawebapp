using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IPrecioCatalogoMap
    {
        TbPrPrecioCatalogo Create(PrecioCatalogoViewModel viewModel);
        TbPrPrecioCatalogo Update(PrecioCatalogoViewModel viewModel);
        TbPrPrecioCatalogo ViewModelToDomain(PrecioCatalogoViewModel viewModel);
        TbPrPrecioCatalogo ViewModelToDomainEditar(PrecioCatalogoViewModel viewModel);
        PrecioCatalogoViewModel DomainToVIewModel(TbPrPrecioCatalogo domain);
    }
}
