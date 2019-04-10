using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class UnidadRepository: BaseRepository<TbPrUnidadMedida>, IUnidadRepository
    {
        public UnidadRepository(EmpresasContext context) : base(context)
        {

        }

        public TbPrUnidadMedida GetUnidadById(int id)
        {
            return context.TbPrUnidadMedida
                .Include(c => c.TbPrConversionIdUnidadDestinoNavigation)
                    .ThenInclude(uc => uc.IdUnidadDestinoNavigation)
                .Include(c => c.TbPrConversionIdUnidadDestinoNavigation)
                    .ThenInclude(uc => uc.IdUnidadOrigenNavigation)
                .Include(c => c.TbPrConversionIdUnidadOrigenNavigation)
                    .ThenInclude(uc => uc.IdUnidadDestinoNavigation)
                .Include(c => c.TbPrConversionIdUnidadOrigenNavigation)
                    .ThenInclude(uc => uc.IdUnidadOrigenNavigation)
                .FirstOrDefault(u => u.Id == id);
        }

        public IList<TbPrUnidadMedida> GetUnidadesConConversiones()
        {
            return context.TbPrUnidadMedida
                .Include(c => c.TbPrConversionIdUnidadDestinoNavigation)
                    .ThenInclude(cu => cu.IdUnidadDestinoNavigation)
                .Include(c => c.TbPrConversionIdUnidadDestinoNavigation)
                    .ThenInclude(cu => cu.IdUnidadOrigenNavigation)
                    .ToList();
        }

    }
}
