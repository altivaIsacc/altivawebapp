using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class DescuentoPromocionRepository : BaseRepository<TbFaRebajaConfig>, IDescuentoPromocionRepository
    {

        public DescuentoPromocionRepository(EmpresasContext context) : base(context)
        {

        }

        public void SaveConfig(TbFaRebajaConfig domain)
        {

            try
            {
                context.TbFaRebajaConfigs.Add(domain);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public TbFaRebajaConfig GetRebajaConfig()
        {
            return context.TbFaRebajaConfigs.FirstOrDefault();
        }
    }
}
