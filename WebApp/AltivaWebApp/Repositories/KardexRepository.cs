using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class KardexRepository: BaseRepository<TbPrKardex>, IKardexRepository
    {
        public KardexRepository(EmpresasContext context) : base(context)
        {

        }


        public IList<TbPrKardex> GetAllKardexByDocumento(int id)
        {
            return context.TbPrKardex.Where(k => k.IdDocumento == id).ToList();
        }

        public IList<TbPrKardex> GetAllKardexByTipoDocumento(string tipo)
        {
            return context.TbPrKardex.Where(k => k.TipoDocumento == tipo).ToList();
        }

        public IList<TbPrKardex> SaveAll(IList<TbPrKardex> domain)
        {
            try
            {
                context.AddRange(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }
    }
}
