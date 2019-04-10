using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class ModuloRepository : BaseRepositoryGE<TbSeModulo>, IModuloRepository
    {
        public ModuloRepository(GrupoEmpresarialContext context) 
            : base(context)
        {

        }

        public TbSeModulo GetModuloById(int id)
        {
            return context.TbSeModulo.FirstOrDefault(m => m.Id == id);
        }
       
    }
}
