using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Services
{
    public interface ITipoProveedorService
    {
        TbFdTipoProveedor Save(TbFdTipoProveedor domain);
        TbFdTipoProveedor GetById(int IdTipoCliente);
        TbFdTipoCliente Updtae(TbFdTipoProveedor domain);
        IList<TbFdTipoProveedor> GetAll();
        bool Delete(TbFdTipoProveedor domain);
    }
}
