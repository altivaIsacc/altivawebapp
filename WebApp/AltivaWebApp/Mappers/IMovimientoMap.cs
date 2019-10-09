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
        void AplicarSaldo(long idUltimoMov, double montoPrepago);
    }
}