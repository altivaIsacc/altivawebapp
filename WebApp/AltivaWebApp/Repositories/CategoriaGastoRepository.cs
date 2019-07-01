using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CategoriaGastoRepository: BaseRepository<TbCpCategoriaGasto>, ICategoriaGastoRepository
    {
        public CategoriaGastoRepository(EmpresasContext context) : base(context)
        {

        }

        public TbCpCategoriaGasto GetCGById(int id)
        {
            return context.TbCpCategoriaGasto.FirstOrDefault(c => c.Id == id);
        }

        public TbCpCategoriaGasto GetCGByNombre(string nombre)
        {
            return context.TbCpCategoriaGasto.FirstOrDefault(c => c.Nombre == nombre);
        }

    }
}
