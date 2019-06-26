using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CajaRepository: BaseRepository<TbFaCaja>, ICajaRepository
    {

        public CajaRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<TbFaCaja> GetInfoCaja()
        {
            try
            {
                return context.TbFaCaja.Include(a => a.IdCaja).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<TbFaCaja> GetAllCajas()
        {
            try
            {
                return context.TbFaCaja.Include(a => a.IdCaja).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbFaCaja GetCajaById(int id)
        {
            try
            {
            //    return context.TbFaCaja.Include(c => c.TbFaCajaAperturaDenominacion).ThenInclude(cd => cd.IdCotizacionNavigation).FirstOrDefault(c => c.IdCotizacion == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
