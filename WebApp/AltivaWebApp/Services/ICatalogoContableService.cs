using AltivaWebApp.DomainsConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ICatalogoContableService
    {
        CatalogoContable Save(CatalogoContable domain);
        CatalogoContable Update(CatalogoContable domain);
        bool Delete(CatalogoContable domain);
        IList<CatalogoContable> GetAll();
        IList<CatalogoContable> GetAllActivas();
        IList<CatalogoContable> GetAllInactivas();
        CatalogoContable GetCatalogoContableById(long id);
        CatalogoContable GetCatalogoContableByNombre(string nombre);
      
    }
}

