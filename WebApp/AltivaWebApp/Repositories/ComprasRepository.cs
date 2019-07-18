using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class ComprasRepository: BaseRepository<TbCpCompras>, IComprasRepository
    {
        public ComprasRepository(EmpresasContext context)
           : base(context)
        {

        }

    }
}
