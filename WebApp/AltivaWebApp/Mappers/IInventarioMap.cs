using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
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
        IList<TbPrImagenInventario> ViewModelToDomainNuevoImagen(int id, IFormFile[] files);
        TbPrInventario ViewModelToDomainEditar(int id, InventarioViewModel viewModel);
        InventarioViewModel DomainToViewModel(TbPrInventario domain);
        InventarioBodegaViewModel DomainToViewModelIBodega(TbPrInventarioBodega domain);
        void CreateInventarioBodega(int idInventario, IList<InventarioBodegaViewModel> viewModelaRel);
        void CreateImagen(int id, IFormFile[] files);
        void CreateCaracteristica(int id, string caracteristica);

    }
}
