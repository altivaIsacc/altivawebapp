using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class TipoJustificanteRepository: BaseRepository<TbFaTipoJustificante>, ITipoJustificanteRepository
    {
        public TipoJustificanteRepository(EmpresasContext context) : base(context)
        {

        }
        public TbFaTipoJustificante GetTipoJustificanteById(long id)
        {
            return context.TbFaTipoJustificante.FirstOrDefault(d => d.IdTipoJustificante == id);
        }

    }
}
