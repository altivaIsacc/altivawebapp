using System.Collections.Generic;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;


namespace AltivaWebApp.Mappers
{
    public interface IMonedaMap
    {
        IList<TbSeMoneda> Create();
        IList<TbSeHistorialMoneda> CreateHM(IList<TbSeMoneda> domain, int idUsuario);
    }
}
