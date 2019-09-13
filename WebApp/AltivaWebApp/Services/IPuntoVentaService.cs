using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IPuntoVentaService
    {

        TbSePuntoVenta Save(TbSePuntoVenta domain);
        TbSePuntoVenta Update(TbSePuntoVenta domain);
        IList<TbSePuntoVenta> GetAll();
        TbSePuntoVenta GetPuntoVentaById(int id);
        bool ExistePuntoVentaValido();
      }
}
