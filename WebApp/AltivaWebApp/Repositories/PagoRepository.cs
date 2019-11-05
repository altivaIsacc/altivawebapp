using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class PagoRepository : BaseRepository<TbFaPago>, IPagoRepository
    {
        public PagoRepository(EmpresasContext context) :base(context){
            
        }

        public TbFaPago GetPagoById(long idPago)
        {
            return context.TbFaPago.FirstOrDefault(p => p.IdPago == idPago);
        }
    }
}
