using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IPuntoVentaRepository
    {
        TbSePuntoVenta GetPuntoVentaById(int id);
        TbSePuntoVenta Save(TbSePuntoVenta domain);
        TbSePuntoVenta Update(TbSePuntoVenta domain);
        IList<TbSePuntoVenta> GetAll();
        

    }
}
