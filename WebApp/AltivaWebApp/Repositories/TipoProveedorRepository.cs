using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class TipoProveedorRepository : BaseRepository<TbFdTipoProveedor>, ITipoProveedorRepository
    {
        public TipoProveedorRepository(EmpresasContext context) : base(context)
        {
        }

        public TbFdTipoProveedor GetById(int idTipoProveedor)
        {
            return context.TbFdTipoProveedor.FirstOrDefault(tc => tc.Id == idTipoProveedor);
        }
    }
}
