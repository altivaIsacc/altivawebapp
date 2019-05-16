using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
   public interface ITipoProveedorRepository
    {
        TbFdTipoProveedor Save(TbFdTipoProveedor domain);
        IList<TbFdTipoProveedor> GetAll();
        TbFdTipoProveedor Update(TbFdTipoProveedor domain);
        TbFdTipoProveedor GetById(int idTipoProveedor);
        bool Delete(TbFdTipoProveedor domain);
        IList<TbFdTipoProveedor> GetTipoProveedor();
        IList<TbFdTipoProveedor> GetFamiliaTipoProveedor(int IdTipoProveedor);
        IList<TbFdTipoProveedor> GetSubFamiliaProveedor(int IdTipoProveedor);
    }
}
