
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
            return context.TbBaFlujoCategoria.AsNoTracking().ToList();
        }

        public TbBaFlujoCategoria GetFlujoCategoriaById(int id)
        {
            return context.TbBaFlujoCategoria.FirstOrDefault(a => a.IdCategoriaFlujo == id);
        }

        public TbBaFlujoCategoria GetFlujoCategoriaByDesc(string cod, int idTipo)
        {
            return context.TbBaFlujoCategoria.FirstOrDefault(a => a.Codigo.ToLower() == cod.ToLower() && a.IdTipoFlujo == idTipo);
        }

        public TbBaFlujoCategoria GetFlujoCategoriaByTipo(int tipo)
        {
            return context.TbBaFlujoCategoria.FirstOrDefault(a => a.IdTipoFlujo == tipo && a.Estado == 1);
        }

        public bool ExisteCatFlujoCadaTipo()
        {
            IList<int> lista = new List<int>();

            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.Add(4);

            var cat = context.TbBaFlujoCategoria.Where(c => c.Estado == 1).ToList();

            var flag = true;
            foreach (var item in lista)
            {
                if (!cat.Any(c => c.IdTipoFlujo == item))
                {
                    flag = false;
                    break;
                }
                    
            }

            return flag;
        }


    }



}
