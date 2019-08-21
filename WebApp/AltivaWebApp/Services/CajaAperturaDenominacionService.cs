using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class CajaAperturaDenominacionService:ICajaAperturaDenominacionRepository
    {
        private readonly ICajaAperturaDenominacionRepository cajaAperturaDenominacionRepository;

        public IList<TbFaCajaAperturaDenominacion> GetAll()
        {
            return cajaAperturaDenominacionRepository.GetAll();
        }
    }
}
