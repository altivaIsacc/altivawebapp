using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ITrasladoInventarioService
    {
        TbPrTrasladoInventario Save(TbPrTrasladoInventario domain);
        TbPrTrasladoInventario Update(TbPrTrasladoInventario domain);
        IList<TbPrTrasladoInventario> GetAllTrasladoInventario(); 
        IList<TbPrTrasladoInventario> GetTrasladoInventarioById(long idTraslado);
      
    }
}
