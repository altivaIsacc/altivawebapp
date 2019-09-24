using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Repositories
{
    public interface IMovimientoRepository
    {
        TbFaMovimiento GetMovimientoById(long id);
        bool SaveMovimientoJustificante(IList<TbFaMovimientoJustificante> domain);
        bool UpdateMovimientoJustificante(IList<TbFaMovimientoJustificante> domain);
        TbFaMovimiento Save(TbFaMovimiento domain);
        TbFaMovimiento Update(TbFaMovimiento domain);
        IList<TbFaMovimiento> GetAllMovimientos();
        TbFaMovimiento GetMovimientoByNota(long id);
        IList<TbFaMovimientoJustificante> GetJustificantesByMovimientoId(long id);
        bool DeleteMovimientoJustificante(IList<int> domain, int idMovimiento);
    }
}
