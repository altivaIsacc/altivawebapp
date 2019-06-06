using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class DescuentoUsuarioRepository : BaseRepository<TbFaDescuentoUsuario>, IDescuentoUsuarioRepository
    {
        public DescuentoUsuarioRepository(EmpresasContext context) : base(context)
        {


        }

        public bool SaveDescUser(IList<TbFaDescuentoUsuario> domain)
        {
            try
            {
                context.TbFaDescuentoUsuario.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }



    }
}
