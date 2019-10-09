using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IMovimientoRepository
    {
        TbFaMovimiento Save(TbFaMovimiento domain);
        TbFaMovimiento Update(TbFaMovimiento domain);
        IList<TbFaMovimientoDetalle> SaveMovDetalle(IList<TbFaMovimientoDetalle> domain);
        TbFaMovimiento GetMovimientoByIdDocumento(long idDoc);
        IList<TbFaMovimientoDetalle> GetMovimientoByIdDocConPagos(long idDoc);
        IList<TbFaMovimientoDetalle> UpdateMovDetalle(IList<TbFaMovimientoDetalle> domain);
        long GetUltimoMovimientoPagoId(long idDoc);
        IList<TbFaMovimiento> GetSaldoContacto(long idContacto);
        TbFaMovimiento GetMovimientoById(long idMov);
    }
}
