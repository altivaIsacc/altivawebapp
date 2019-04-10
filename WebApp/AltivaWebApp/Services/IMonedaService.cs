using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
   public interface IMonedaService
    {
        TbSeMoneda Create(TbSeMoneda domain);
        TbSeMoneda UpdateMoneda(TbSeMoneda domain);
        void Delete(TbSeMoneda domain);
        IList<TbSeMoneda> GetAll();
        TbSeMoneda GetMoneda(int id);

        void CrearMoneda(IList<TbSeMoneda>  historial);
    }
}
