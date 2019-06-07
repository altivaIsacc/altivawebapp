using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class ColaAprobacionRepository: BaseRepository<TbCeColaAprobacion>, IColaAprobacionRepository
    {
        public ColaAprobacionRepository(EmpresasContext context) 
            :base(context)
        {

        }
        public IList<TbCeColaAprobacion> GetAllSinAnular()
        {
            return context.TbCeColaAprobacion.Where(c => c.Anulado == false).ToList();
        }
        public TbCeColaAprobacion GetByIdDoc(long id)
        {
            return context.TbCeColaAprobacion.FirstOrDefault(c => c.IdDoc == id);
        }



    }
}
