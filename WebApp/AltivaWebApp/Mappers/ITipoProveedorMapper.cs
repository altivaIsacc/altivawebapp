using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
   public interface ITipoProveedorMapper
    {
        TbFdTipoProveedor Save(TipoClienteViewModel domain);
        TbFdTipoProveedor Update(TipoClienteViewModel domain);
        TbFdTipoProveedor ViewModelToDomain(TipoClienteViewModel domain);
        TipoClienteViewModel DomainToViewModel(TbFdTipoProveedor domain);
    }
}
