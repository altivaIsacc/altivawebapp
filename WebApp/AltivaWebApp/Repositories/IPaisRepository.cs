using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Repositories
{
  public  interface IPaisRepository
    {
        TbSePais Save(TbSePais domain);
        TbSePais borrar(int domian);

        TbSePais Update(TbSePais domain);
        IList<TbSePais> GetAll();
        TbSePais GetPaisById(int id);


    }
}
