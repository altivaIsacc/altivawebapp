using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Mappers
{
    public interface ITipoClienteMapper
    {
        TbFdTipoCliente Save(TbFdTipoCliente domain);
        TbFdTipoCliente ViewModelToSave(TbFdTipoCliente domain);
        TbFdTipoCliente Update(TbFdTipoCliente domain);
        TbFdTipoCliente ViewModelToUpdate(TbFdTipoCliente domain);
    }
}
