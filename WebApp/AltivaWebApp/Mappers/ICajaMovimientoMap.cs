using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface ICajaMovimientoMap
    {
        IList<TbFaCajaMovimiento> CreateCajaMovimiento(IList<CajaMovimientoViewModel> viewModel, long idMovimiento);
        IList<TbFaCajaMovimiento> UpdateCajaMovimiento(IList<CajaMovimientoViewModel> viewModel, long idMovimiento);
        List<CajaMovimientoViewModel> GetLineasPago(double idDoc);
    }
}
