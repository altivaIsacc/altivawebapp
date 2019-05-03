using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
  public  interface ITipoClienteRepository
    {
        TbFdTipoCliente Save(TbFdTipoCliente domain);
        IList<TbFdTipoCliente> GetAll();
        TbFdTipoCliente Update(TbFdTipoCliente domain);
        TbFdTipoCliente GetById(int idTipoCliente);
        bool Delete(TbFdTipoCliente domain);
        IList<TbFdTipoCliente> GetTipoCliente();
        IList<TbFdTipoCliente> GetFamiliaTipoCliente(int IdTipoCLiente);
        IList<TbFdTipoCliente> GetSubFamilia(int IdTipoCliente);

    }
}
