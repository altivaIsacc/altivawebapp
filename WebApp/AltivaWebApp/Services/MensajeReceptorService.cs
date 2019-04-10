using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class MensajeReceptorService : IMensajeReceptorService
    {

        private IMensajeReceptorRepository IMensajeReceptor;
        public MensajeReceptorService(IMensajeReceptorRepository pIMensajeReceptor)
        {
            this.IMensajeReceptor = pIMensajeReceptor;
        }
        public void Crear(List<TbSeMensajeReceptor> MensajeReceptor)
        {
            this.IMensajeReceptor.Crear(MensajeReceptor);
        }

        public TbSeMensajeReceptor Update(TbSeMensajeReceptor domain)
        {
            return this.IMensajeReceptor.Update(domain);
        }
    }
}
