using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
  public  interface ITipoJustificanteService
    {
        TbFaTipoJustificante Save(TbFaTipoJustificante domain);
        TbFaTipoJustificante Update(TbFaTipoJustificante domain);
        IList<TbFaTipoJustificante> GetAll();
       TbFaTipoJustificante GetTipoJustificanteById(long id);
       
    }
}
