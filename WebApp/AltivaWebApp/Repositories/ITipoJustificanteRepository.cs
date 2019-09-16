using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface ITipoJustificanteRepository
    {
        TbFaTipoJustificante Save(TbFaTipoJustificante domain);
        TbFaTipoJustificante Update(TbFaTipoJustificante domain);
        IList<TbFaTipoJustificante> GetAll();
        TbFaTipoJustificante GetTipoJustificanteById(long id);
    }

}
