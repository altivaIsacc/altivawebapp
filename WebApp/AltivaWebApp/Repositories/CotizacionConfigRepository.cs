using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;

namespace AltivaWebApp.Repositories
{
    public class CotizacionConfigRepository:BaseRepository<TbFaCotizacionConfig>,ICotizacionConfigRepository
    {
        public CotizacionConfigRepository(EmpresasContext context) : base(context)
        {

        }
    }
}
