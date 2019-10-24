using AltivaWebApp.DomainsConta;
using System.Collections.Generic;

namespace AltivaWebApp.Repositories
{
    public interface ICatalogoContableRepository
    {
        CatalogoContable Save(CatalogoContable domain);
        CatalogoContable Update(CatalogoContable domain);
        bool Delete(CatalogoContable domain);
        IList<CatalogoContable> GetAllActivas();
        IList<CatalogoContable> GetAll();
        CatalogoContable GetCatalogoContableById(long id);
        CatalogoContable GetCatalogoContableByNombre(string nombre);
        IList<CatalogoContable> GetAllInactivas();
       
       
    }
}