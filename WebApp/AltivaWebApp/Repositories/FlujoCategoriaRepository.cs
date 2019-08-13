
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//agregado por lenin
namespace AltivaWebApp.Repositories
{
    //implementa la interfaces
    public class FlujoCategoriaRepository : BaseRepository<TbBaFlujoCategoria>, IFlujoCategoriaRepository
    {

        public FlujoCategoriaRepository(EmpresasContext context)
          : base(context)
        {

        }

        public IList<TbBaFlujoCategoria> GetAllFlujoCategoria()
        {
            return context.TbBaFlujoCategoria.ToList();
        }

        public TbBaFlujoCategoria GetFlujoCategoriaById(int id)
        {
            return context.TbBaFlujoCategoria.FirstOrDefault(a => a.IdCategoriaFlujo == id);
        }

        public TbBaFlujoCategoria GetFlujoCategoriaByDesc(string cod, int idTipo)
        {
            return context.TbBaFlujoCategoria.FirstOrDefault(a => a.Codigo.ToLower() == cod.ToLower() && a.IdTipoFlujo == idTipo);
        }




    }



}
