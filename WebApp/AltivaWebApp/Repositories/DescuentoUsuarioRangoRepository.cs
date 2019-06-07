using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class DescuentoUsuarioRangoRepository : BaseRepository<TbFaDescuentoUsuarioRango>, IDescuentoUsuarioRangoRepository
    {
        public DescuentoUsuarioRangoRepository(EmpresasContext context) : base(context)
        {


        }

        public bool SaveDescUserRango(IList<TbFaDescuentoUsuarioRango> domain)
        {
            try
            {
                context.TbFaDescuentoUsuarioRango.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public TbFaDescuentoUsuarioRango GetDescuentoUsuarioRangoById(int id)
        {

            return context.TbFaDescuentoUsuarioRango.FirstOrDefault(f => f.IdDescuentoUsuarioRango == id);
        }
    }
}
