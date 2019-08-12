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
     
        bool Update(IList<PrecioCatalogoViewModel> viewModel);
        TbPrPrecioCatalogo ViewModelToDomain(PrecioCatalogoViewModel viewModel);
        IList<TbPrPrecioCatalogo> ViewModelToDomainEditar(IList<PrecioCatalogoViewModel> viewModel);
        PrecioCatalogoViewModel DomainToVIewModel(TbPrPrecioCatalogo domain);
    }
}
