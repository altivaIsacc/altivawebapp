using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class DescuentoProductoRepository : BaseRepository<TbFaDescuentoProducto>, IDescuentoProductoRepository
    {
        public DescuentoProductoRepository(EmpresasContext context) : base(context)
        {


        }

        public bool SaveDescProd(IList<TbFaDescuentoProducto> domain)
        {
            try
            {
                foreach (var item in domain)
                {
                    if (item.IdDescuentoProducto == 0)
                    {
                        context.TbFaDescuentoProducto.Add(item);
                    }
                    else
                    {
                        context.TbFaDescuentoProducto.Update(item);
                    }
                }
                //context.TbFaDescuentoUsuario.AddRange(domain);
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

        public TbFaDescuentoProducto GetDescuentoProductoById(int id)
        {

            return context.TbFaDescuentoProducto.FirstOrDefault(f => f.IdDescuentoProducto == id);
        }
    }
}
