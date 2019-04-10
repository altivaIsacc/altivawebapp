using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Repositories
{
    public class AdjuntoRepository : BaseRepositoryGE<TbSeAdjunto>, IAdjuntoRepository
    {
        public AdjuntoRepository(GrupoEmpresarialContext context) : base(context)
        {
        }

        public void Crear(List<TbSeAdjunto> pAdjunto)
        {
            context.TbSeAdjunto.AddRange(pAdjunto);
            context.SaveChanges();

            

        }
    }
}
