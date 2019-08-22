using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AltivaWebApp.Repositories
{
    public class TrasladoInventarioRepository : BaseRepository<TbPrTrasladoInventario>, ITrasladoInventarioRepository
    {

        public TrasladoInventarioRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<TbPrTrasladoInventario> GetAllTrasladoInventario()
        {
            return context.TbPrTrasladoInventario.Include(a => a.IdTrasladoNavigation).Include(a => a.IdInventarioNavigation).ToList();//.Include(a => a.IdInventarioBodegaNavigation)
        }


        //sirve
        public IList<TbPrTrasladoInventario> GetTrasladoInventarioById(long idTraslado)
        {
            //return context.TbPrTrasladoInventario.FirstOrDefault(d => d.IdTraslado == idTraslado);//la forania de mi tabla por la que viene de la vista
            return context.TbPrTrasladoInventario.Where(f => f.IdTraslado == idTraslado).ToList();//trae los que coincidan con el idtraslado
           
        }

        

    }
}
