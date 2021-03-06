﻿using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IMovimientoService
    {
        TbFaMovimiento Save(TbFaMovimiento domain);
        TbFaMovimiento Update(TbFaMovimiento domain);
        IList<TbFaMovimientoDetalle> SaveMovDetalle(IList<TbFaMovimientoDetalle> domain);
        IList<TbFaMovimiento> GetMovimientosByIdDocumento(long idDoc);
        IList<TbFaMovimientoDetalle> UpdateMovDetalle(IList<TbFaMovimientoDetalle> domain);
        long GetUltimoMovimientoPagoId(long idDoc);
        IList<TbFaMovimiento> GetSaldoContacto(long idContacto);
        TbFaMovimiento GetMovimientoById(long idMov);
    }
}
