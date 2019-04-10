using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
namespace AltivaWebApp.Services
{
  public  interface IPaisService
    {
        TbSePais Create(TbSePais collection);
        TbSePais UpdatePais(TbSePais domain);
        TbSePais Delete(int id);
        IList<TbSePais> GetAll();
        TbSePais GetPaisById(int id);
    }
}
