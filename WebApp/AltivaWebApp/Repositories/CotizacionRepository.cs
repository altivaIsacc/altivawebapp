using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CotizacionRepository:BaseRepository<TbFaCotizacion>, ICotizacionRepository
    {
        public CotizacionRepository(EmpresasContext context): base(context)
        {
         
        }
 
    
        public IList<TbFaCotizacion> GetInfoCotizacion()
        {
            try
            {
                return context.TbFaCotizacion
                                .Include(a => a.IdClienteNavigation).ToList();
                                
            }
            catch (Exception)
            {
                throw;
            }
        }
       

    }
}
