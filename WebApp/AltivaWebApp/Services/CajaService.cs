using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class CajaService:ICajaService
    {
        private readonly ICajaRepository repository;

        public CajaService(ICajaRepository cajaRepository)
        {
            repository = cajaRepository;
        }

        public IList<TbFaCajaArqueo> GetAllById(int id)
        {
            return repository.GetAllById(id);
        }

        public IList<TbFaCajaAperturaDenominacion> GetAllCajaAperturaDenominacionByIdCaja(int id)
        {
            return repository.GetAllCajaAperturaDenominacionByIdCaja(id);
        }

        public IList<TbFaCajaArqueoDenominacion> GetAllCajaArqueoDenominacionByIdCaja(int id)
        {
            return repository.GetAllCajaArqueoDenominacionByIdCaja(id);
        }

        public IList<TbFaCajaArqueo> GetAllCajaArqueoByIdCaja(int id)
        {
            return repository.GetAllCajaArqueoByIdCaja(id);
        }

        public IList<TbFaCaja> GetInfoCaja()
        {
            return repository.GetInfoCaja();
        }

        public bool UpdateCajaAperturaDenominacion(IList<TbFaCajaAperturaDenominacion> domain)
        {
            return repository.UpdateCajaAperturaDenominacion(domain);
        }

        public bool UpdateCajaArqueo(IList<TbFaCajaArqueo> domain)
        {
            return repository.UpdateCajaArqueo(domain);
        }

        public bool UpdateCajaArqueoDenominacion(IList<TbFaCajaArqueoDenominacion> domain)
        {
            return repository.UpdateCajaArqueoDenominacion(domain);
        }


        public TbFaCajaAperturaDenominacion SaveCajaAperturaDenominacion(TbFaCajaAperturaDenominacion domain)
        {
            return repository.SaveCajaAperturaDenominacion(domain);
        }

        public IList<TbFaCaja> GetAllCajas()
        {
            return repository.GetAllCajas();
        }

        public TbFaCaja GetCajaById(int id)
        {
            return repository.GetCajaById(id);
        }

        public TbFaCaja Save(TbFaCaja domain)
        {
            return repository.Save(domain);
        }

        public TbFaCaja Update(TbFaCaja domain)
        {
            return repository.Update(domain);
        }
    }
}
