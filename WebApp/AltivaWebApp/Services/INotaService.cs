using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface INotaService
    {
        IList<TbFaNota> GetAll();
        TbFaNota GetNotaById(long id);
        TbFaNota Save(TbFaNota domain);
        TbFaNota Update(TbFaNota domain);
        IList<TbFaTipoDocumento> GetAllTipoDocumento();
        TbFaMovimiento SaveMovimiento(TbFaMovimiento domain);
        TbFaPago GetPagoById(long id);
        TbFaPago UpdateDoc(TbFaPago domain);

    }
}
