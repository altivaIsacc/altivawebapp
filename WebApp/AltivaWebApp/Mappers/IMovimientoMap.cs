using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IMovimientoMap
    {
        TbFaMovimiento CreateMovimientoPago(long idDoc, IList<CajaMovimientoViewModel> formasPago, double montoPrepago);
        void AplicarSaldo(long idUltimoMov, double montoPrepago, long idDocumento);
        TbFaMovimiento Create(MovimientoViewModel viewModel);
        TbFaMovimiento Update(MovimientoViewModel viewModel);
        bool CreateMJ(MovimientoViewModel viewModel);
        bool UpdateMJ(MovimientoViewModel viewModel);
        MovimientoViewModel DomainToViewModel(TbFaMovimiento domain);
        TbFaMovimiento ViewModelToDomain(MovimientoViewModel viewModel);
        IList<TbFaMovimientoJustificante> ViewModelToDomainMJ(MovimientoViewModel viewModel);
        TbFaMovimientoJustificante ViewModelToDomainSingleMj(MovimientoJustificanteViewModel viewModel, MovimientoViewModel movimiento);
        bool CreateMD(IList<MovimientoDetalleViewModel> viewModel);
        bool UpdateMD(IList<MovimientoDetalleViewModel> viewModel);
    }
}
