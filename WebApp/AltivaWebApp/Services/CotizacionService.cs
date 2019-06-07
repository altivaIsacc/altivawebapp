using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class CotizacionService:ICotizacionService
    {
        private readonly ICotizacionRepository repository;

        public CotizacionService(ICotizacionRepository cotizacionRepository)
        {
            repository = cotizacionRepository;
        }
 
        public IList< TbFaCotizacion> GetInfoCotizacion()
        {
            return repository.GetInfoCotizacion();
        }

        public IList<TbFaCotizacionDetalle> GetAllCotizacionDetalleByIdCotizacion(int id)
        {
            return repository.GetAllCotizacionDetalleByIdCotizacion(id);
        }

        public TbFaCotizacion Save(TbFaCotizacion domain)
        {
            return repository.Save(domain);
        }

        public TbFaCotizacion Update(TbFaCotizacion domain)
        {
            return repository.Update(domain);
        }

        public IList<TbFaCotizacion> GetAllCotizacion()
        {
            return repository.GetAllCotizacion();
        }

        public TbFaCotizacion GetCotizacionById(int id)
        {
            return repository.GetCotizacionById(id);
        }


        public TbFaCotizacionDetalle SaveCotizacionDetalle(TbFaCotizacionDetalle domain)
        {
            return repository.SaveCotizacionDetalle(domain);
        }

        public bool DeleteCotizacionDetalle(TbFaCotizacionDetalle domain)
        {
            return repository.DeleteCotizacionDetalle(domain);
        }

        public bool UpdateCompraDetalle(IList<TbFaCotizacionDetalle> domain)
        {
            return repository.UpdateCotizacionDetalle(domain);
        }

        public TbFaCotizacionDetalle GetCotizacionDetalleById(long id)
        {
            return repository.GetCotizacionDetalleById(id);
        }

        public bool UpdateCotizacionDetalle(IList<TbFaCotizacionDetalle> domain)
        {
            return repository.UpdateCotizacionDetalle(domain);
        }


    }
}
