using AltivaWebApp.Context;
using AltivaWebApp.DomainsConta;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AltivaWebApp.Repositories
{
    public class CatalogoContableRepository : BaseContaRepository<CatalogoContable>, ICatalogoContableRepository
    {
        public CatalogoContableRepository(BaseConta context)
            : base(context)
        {

        }

        public CatalogoContable GetCatalogoContableById(long id)
        {
            return context.CatalogoContable.Where(b => b.IdCuentaContable == id).FirstOrDefault();

        }
        public CatalogoContable GetCatalogoContableByNombre(string nombre)
        {
            return context.CatalogoContable.FirstOrDefault(b => b.Descripcion == nombre);
        }
        public IList<CatalogoContable> GetAllActivas()
        {
            return context.CatalogoContable.Where(b => b.Inactivo == true).ToList();
        }
        public IList<CatalogoContable> GetAllInactivas()
        {
            return context.CatalogoContable.Where(b => b.Inactivo == false).ToList();
        }



    }
}
