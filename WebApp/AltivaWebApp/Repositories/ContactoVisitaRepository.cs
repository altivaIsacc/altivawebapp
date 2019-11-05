using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class ContactoVisitaRepository : BaseRepository<TbCrContactoVisita>, IContactoVisitaRepository
    {

        public ContactoVisitaRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<TbCrContactoVisita> GetAllContactoVisita()
        {
            return context.TbCrContactoVisita.Include(c => c.IdVisitaTipoNavigation).ToList();
            //context.TbCrContactoVisita.AsNoTracking().ToList();
            //context.TbCrContactoVisita.Include(c => c.IdVisitaTipoNavigation).ToList();
           
        }

        public TbCrContactoVisita GetContactoVisitaById(long id)
        {
            return context.TbCrContactoVisita.AsNoTracking().FirstOrDefault(c => c.IdContactoVisita == id);
        }




    }
}
