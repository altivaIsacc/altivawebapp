using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IContactoVisitaRepository
    {
        TbCrContactoVisita Save(TbCrContactoVisita domain);
        TbCrContactoVisita Update(TbCrContactoVisita domain);
        IList<TbCrContactoVisita> GetAllContactoVisita();
        TbCrContactoVisita GetContactoVisitaById(long id);
    }
}
