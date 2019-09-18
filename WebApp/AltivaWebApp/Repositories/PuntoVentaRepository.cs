using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AltivaWebApp.Repositories
{
    public class PuntoVentaRepository : BaseRepository<TbSePuntoVenta>, IPuntoVentaRepository
    {
        public PuntoVentaRepository(EmpresasContext context) : base(context)
        {

        }

        public TbSePuntoVenta GetPuntoVentaById(int id)
        {
            return context.TbSePuntoVenta
                .Include(p => p.IdTipoPrecioDefectoNavigation)
                .FirstOrDefault(d => d.IdPuntoVenta == id);
        }

        public bool ExistePuntoVentaValido()
        {
            return context.TbSePuntoVenta.Any(p => p.EsPorDefecto && !p.Inactivo && p.IdBodega != 0 && p.IdContactoClienteDefecto != 0 && p.IdTipoPrecioDefecto != 0 );
        }

        public int GetEstadoCajasPV(long idPV, long idUsuario)
        {
            var pv = context.TbSePuntoVenta.Include(p => p.TbFaCaja).FirstOrDefault(p => p.IdPuntoVenta == idPV);
            if (pv.TieneCajaIndependiente)
            {
                return pv.TbFaCaja.Where(c => c.Estado == 1 && c.IdUsuario == idUsuario).Count();
            }
            else
            {
                return context.TbFaCaja.Where(c => c.Estado == 1 && c.IdUsuario == idUsuario).Count();
            }
           
        }




    }
}
