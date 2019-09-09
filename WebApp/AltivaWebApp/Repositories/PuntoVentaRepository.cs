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
            return context.TbSePuntoVenta.FirstOrDefault(d => d.IdPuntoVenta == id);
        }

       

       

    }
}
