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
        IList<TbSeMoneda> SaveMoneda(IList<TbSeMoneda> domain);
        IList<TbSeMoneda> UpdateMoneda(IList<TbSeMoneda> domain);
        IList<TbSeMoneda> GetAll();
        IList<TbSeHistorialMoneda> GetAllHMPorMoneda(int codigo);
        TbSeMoneda GetMonedaById(int id);
        TbSeHistorialMoneda CrearHistorialMonedaSingle(TbSeHistorialMoneda domain);
        IList<TbSeHistorialMoneda> CrearHistorialMoneda(IList<TbSeHistorialMoneda> historial);
        TbSeHistorialMoneda EditarHistorialMoneda(TbSeHistorialMoneda historial);
        TbSeHistorialMoneda GetHMById(long id);
    }
}
