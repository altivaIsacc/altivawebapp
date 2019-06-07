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
        TbPrCompraDetalle CreateCD(CompraViewModel viewModel);
        CompraViewModel DomainToViewModel(TbPrCompra domain);
        bool UpdateCD(CompraViewModel viewModel);

    }
}
