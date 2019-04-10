using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
   public interface IMonedaRepository
    {
        TbSeMoneda Save(TbSeMoneda domain);
        TbSeMoneda Update(TbSeMoneda domain);
        IList<TbSeMoneda> GetAll();
        TbSeMoneda GetMonedaById(int id);
        TbSeMoneda GetMonedaByfecha(string id);
       void CrearMoneda(IList<TbSeMoneda>  historial);

    }
}
