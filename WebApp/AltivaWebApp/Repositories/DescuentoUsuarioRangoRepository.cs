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
                foreach (var item in domain)
                {
                    if (item.IdDescuentoUsuarioRango == 0)
                    {
                        context.TbFaDescuentoUsuarioRango.Add(item);
                    }
                    else
                    {
                        context.TbFaDescuentoUsuarioRango.Update(item);
                    }
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
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
