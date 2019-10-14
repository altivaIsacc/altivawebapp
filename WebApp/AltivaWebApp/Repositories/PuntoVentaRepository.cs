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
            return context.TbSePuntoVenta.Any(p => p.EsPorDefecto && !p.Inactivo);
        }

        public int GetEstadoCajasPV(long idPV, long idUsuario)
        {
            var pv = context.TbSePuntoVenta.Include(p => p.TbFaCaja).FirstOrDefault(p => p.IdPuntoVenta == idPV);
            if (pv.TieneCajaIndependiente)
            {
                var caja = pv.TbFaCaja.FirstOrDefault(c => c.Estado == 1 && c.IdUsuario == idUsuario);
                return caja != null ? (int)caja.IdCaja : 0; 
            }
            else
            {
                var caja = context.TbFaCaja.FirstOrDefault(c => c.Estado == 1 && c.IdUsuario == idUsuario);
                return caja != null ? (int)caja.IdCaja : 0;
            }
           
        }




    }
}
