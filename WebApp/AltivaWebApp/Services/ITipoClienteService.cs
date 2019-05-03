using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Services
{
   public  interface ITipoClienteService
    {
        TbFdTipoCliente Save(TbFdTipoCliente domain);
        TbFdTipoCliente GetById(int IdTipoCliente);
        TbFdTipoCliente Updtae(TbFdTipoCliente domain);
        IList<TbFdTipoCliente> GetAll();
        bool Delete(TbFdTipoCliente domain);

    }
}
