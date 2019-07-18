using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class ComprasDetalleServicioRepository : BaseRepository<TbCpComprasDetalleServicio>, IComprasDetalleServicio
    {
        public ComprasDetalleServicioRepository(EmpresasContext context)
            : base(context)
        {

        }

    }
}
