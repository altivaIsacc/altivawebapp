using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface ITrasladoInventarioRepository
    {
        TbPrTrasladoInventario Save(TbPrTrasladoInventario domain);
        TbPrTrasladoInventario Update(TbPrTrasladoInventario domain);
        IList<TbPrTrasladoInventario> GetAllTrasladoInventario();
        TbPrTrasladoInventario GetTrasladoInventarioById(long idTraslado);

    }
}
