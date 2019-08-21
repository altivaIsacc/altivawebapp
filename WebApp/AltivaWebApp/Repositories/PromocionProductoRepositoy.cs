using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class PromocionProductoRepositoy : BaseRepository<TbFaPromocionProducto>, IPromocionProductoRepository
    {
        public PromocionProductoRepositoy(EmpresasContext context) : base(context)
        {


        }

        public bool SavePromocion(IList<TbFaPromocionProducto> domain)
        {
            try
            {
                foreach (var item in domain)
                {
                    if (item.IdPromocionProducto == 0)
                    {
                        context.TbFaPromocionProducto.Add(item);
                    }
                    else
                    {
                        context.TbFaPromocionProducto.Update(item);
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

        public TbFaPromocionProducto GetPromocionById(int id)
        {

            return context.TbFaPromocionProducto.FirstOrDefault(f => f.IdPromocionProducto == id);
        }
    
    }
}
