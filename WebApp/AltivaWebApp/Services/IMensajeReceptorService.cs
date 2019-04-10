using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
namespace AltivaWebApp.Services
{
 public  interface IMensajeReceptorService
    {
        void Crear(List<TbSeMensajeReceptor> MensajeReceptor);

        TbSeMensajeReceptor Update(TbSeMensajeReceptor domain);
    }
}
