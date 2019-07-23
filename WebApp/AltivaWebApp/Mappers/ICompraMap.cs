using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface ICompraMap
    {

        TbPrCompra Create(CompraViewModel viewModel);
        TbPrCompra Update(CompraViewModel viewModel);
        TbPrCompra CreateGasto(CompraServicioViewModel viewModel);
        TbPrCompra UpdateGasto(CompraServicioViewModel viewModel);
        TbPrCompraDetalle CreateCD(CompraViewModel viewModel);
        TbCpComprasDetalleServicio CreateCDS(CompraServicioViewModel viewModel);
        CompraViewModel DomainToViewModel(TbPrCompra domain);
        CompraServicioViewModel DomainToViewModelGasto(TbPrCompra domain);
        bool UpdateCD(CompraViewModel viewModel);
        bool UpdateCDS(CompraServicioViewModel viewModel);

    }
}