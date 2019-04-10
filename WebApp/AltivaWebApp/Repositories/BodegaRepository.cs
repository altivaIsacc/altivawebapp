using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class BodegaRepository: BaseRepository<TbPrBodega>, IBodegaRepository
    {
        public BodegaRepository(EmpresasContext context) 
            :base(context)
        {

        }

        public TbPrBodega GetBodegaById(int id)
        {
            return context.TbPrBodega.FirstOrDefault(b => b.Id == id);
        }
        public TbPrBodega GetBodegaByNombre(string nombre)
        {
            return context.TbPrBodega.FirstOrDefault(b =>b.Nombre == nombre);
        }
        public IList<TbPrBodega> GetAllActivas()
        {
            return context.TbPrBodega.Where(b => b.Estado == true).ToList();
        }
        public IList<TbPrBodega> GetAllInactivas()
        {
            return context.TbPrBodega.Where(b => b.Estado == false).ToList();
        }

    }
}
