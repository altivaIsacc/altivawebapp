using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IBodegaMap
    {
        TbPrBodega Create(BodegaViewModel viewModel);
        TbPrBodega Update(BodegaViewModel viewModel, int id);
        TbPrBodega ViewModelToDomainNuevo(BodegaViewModel viewModel);
        TbPrBodega ViewModelToDomainEditar(BodegaViewModel viewModel, int id);
        BodegaViewModel DomainToViewModel(TbPrBodega domain);
    }
}
