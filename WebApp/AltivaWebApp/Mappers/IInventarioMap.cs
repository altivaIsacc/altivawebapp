using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IInventarioMap
    {
        TbPrInventario Create(InventarioViewModel viewModel);
        TbPrInventario Update(int id, InventarioViewModel viewModel);
        TbPrInventario ViewModelToDomainNuevo(InventarioViewModel viewModel);
        TbPrInventario ViewModelToDomainEditar(int id, InventarioViewModel viewModel);
        InventarioViewModel DomainToViewModel(TbPrInventario domain);
        void CreateInventarioBodega(int idInventario, IList<InventarioBodegaViewModel> viewModelaRel);
    }
}
