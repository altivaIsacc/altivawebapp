using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
  public  interface IConfiguracionFiltrosRepository
    {
        TbFdConfiguracionFiltros Save(TbFdConfiguracionFiltros domain);
        void DeleteRange(IList<TbFdConfiguracionFiltros> domain);
        TbFdConfiguracionFiltros GetFiltro();
        bool Delete(TbFdConfiguracionFiltros domain);
    }
}
