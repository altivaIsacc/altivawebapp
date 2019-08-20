using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class FamiliaRepository: BaseRepository<TbPrFamilia>, IFamiliaRepository
    {
        public FamiliaRepository(EmpresasContext context) : base(context)
        {

        }

        public TbPrFamilia GetFamiliaById(int id)
        {
            return context.TbPrFamilia.Include(f => f.InverseIdFamiliaNavigation).FirstOrDefault(f => f.Id == id);
        }

        public IList<TbPrFamilia> GetAllFamilias()
        {
            return context.TbPrFamilia.Include(f => f.InverseIdFamiliaNavigation).Where(f => f.IdFamilia == null).ToList();
        }
        public IList<TbPrFamilia> GetAllSubFamilias()
        {
            return context.TbPrFamilia.Where(f => f.IdFamilia != null).ToList();
        }

        public TbPrFamilia GetFamiliaByDescripcion(string descripcion)
        {
            return context.TbPrFamilia.FirstOrDefault(f => f.Descripcion == descripcion);
        }

        public void UpdateSubFamilia(IList<TbPrFamilia> subFamilias)
        {
            try
            {
                context.TbPrFamilia.UpdateRange(subFamilias);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }
    }
}
