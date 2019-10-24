using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IContactoVisitaService
    {
        TbCrContactoVisita Save(TbCrContactoVisita domain);
        TbCrContactoVisita Update(TbCrContactoVisita domain);
        IList<TbCrContactoVisita> GetAllContactoVisita();
        TbCrContactoVisita GetContactoVisitaById(long id);

    }
}
