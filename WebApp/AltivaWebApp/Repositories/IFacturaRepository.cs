﻿using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IFacturaRepository
    {
        IList<TbFdFactura> GetAllFacturas();
        TbFdFactura Save(TbFdFactura Factura);
        TbFdFactura Update(TbFdFactura Factura);
        TbFdFactura GetFacturaById(long id);
        IList<TbFdFacturaDetalle> GetFacturaDetalleById(long id);
        IList<TbFdFacturaDetalle> SaveFacturaDetalle(IList<TbFdFacturaDetalle> domain);
        IList<TbFdFacturaDetalle> UpdateFacturaDetalle(IList<TbFdFacturaDetalle> domain);
        bool DeleteFacturaDetalle(IList<long> domain);
        long GetIdTipoPrecioCliente(long idCliente);
    }
}
