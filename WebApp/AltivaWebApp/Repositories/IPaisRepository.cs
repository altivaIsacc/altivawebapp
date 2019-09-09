using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Repositories
{
  public  interface IPaisRepository
    {
        TbSePais Save(TbSePais pais);
        TbSePais borrar(int idPais);

        TbSePais Update(TbSePais pais);
        IList<TbSePais> GetAll();
        TbSePais GetPaisById(int idPais);
        TbSePais ConsultarPais(PaisViewModel viewModel);

    }
}
