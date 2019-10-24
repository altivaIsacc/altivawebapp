using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class VisitaTipoRepository : BaseRepository<TbCrVisitaTipo>, IVisitaTipoRepository
    {
        public VisitaTipoRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<TbCrVisitaTipo> GetAllVisitaTipo()
        {
            return context.TbCrVisitaTipo.AsNoTracking().ToList();
        }

        public TbCrVisitaTipo GetVisitaTipoById(int id)
        {
            return context.TbCrVisitaTipo.AsNoTracking().FirstOrDefault(d => d.IdVisitaTipo == id);
        }





    }
}
