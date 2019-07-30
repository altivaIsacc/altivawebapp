using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class DescuentoUsuarioClaveRepository: BaseRepository<TbFaDescuentoUsuarioClave>, IDescuentoUsuarioClaveRepository
    {
        public DescuentoUsuarioClaveRepository(EmpresasContext context) : base(context)
        {


        }

        public bool SaveDescUserClave(IList<TbFaDescuentoUsuarioClave> domain)
        {
            try
            {
                foreach (var item in domain)
                {
                    if (item.IdDescuentoUsuario == 0)
                    {
                        context.TbFaDescuentoUsuarioClave.Add(item);
                    }
                    else
                    {
                        context.TbFaDescuentoUsuarioClave.Update(item);
                    }
                }
                //context.TbFaDescuentoUsuario.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public TbFaDescuentoUsuarioClave GetDescuentoUsuarioClaveById(int id)
        {

            return context.TbFaDescuentoUsuarioClave.FirstOrDefault(f => f.IdDescuentoUsuario == id);
        }
    }
}
