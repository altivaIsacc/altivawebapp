using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Mappers
{
   public interface ITipoProveedorMapper
    {
        TbFdTipoProveedor Save(TbFdTipoProveedor domain);
        TbFdTipoProveedor ViewModelToSave(TbFdTipoProveedor domain);
        TbFdTipoProveedor Update(TbFdTipoProveedor domain);
        TbFdTipoProveedor ViewModelToUpdate(TbFdTipoProveedor domain);
    }
}
