using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
namespace AltivaWebApp.Repositories
{
   public interface IMensajeReceptorRepository
    {
        TbSeMensajeReceptor Update(TbSeMensajeReceptor MensajeReceptor);
        void Crear(List<TbSeMensajeReceptor> MensajeReceptor);
        TbSeMensajeReceptor Consultar(int id);
        TbSeMensajeReceptor Save(TbSeMensajeReceptor MensajeReceptor);
    }
}
