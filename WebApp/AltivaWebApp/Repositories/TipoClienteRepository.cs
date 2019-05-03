using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class TipoClienteRepository :BaseRepository<TbFdTipoCliente> ,ITipoClienteRepository
    {
        public TipoClienteRepository(EmpresasContext context) : base(context)
        {
        }

        public TbFdTipoCliente GetById(int idTipoCliente)
        {
            return context.TbFdTipoCliente.FirstOrDefault(tc => tc.Id == idTipoCliente);
        }
    }
}
