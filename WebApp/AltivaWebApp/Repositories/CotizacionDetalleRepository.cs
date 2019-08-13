using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CotizacionDetalleRepository:BaseRepository<TbFaCotizacionDetalle>,ICotizacionDetalleRepository
    {
        public CotizacionDetalleRepository(EmpresasContext context) : base(context)
        {

        }
    }
}
