﻿using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class FamiliaOnlineRepository : BaseRepository<TbPrFamiliaVentaOnline>, IFamiliaOnlineRepository
    {
        public FamiliaOnlineRepository(EmpresasContext context) : base(context)
        {

        }

        public TbPrFamiliaVentaOnline GetFamiliaById(int id)
        {
            return context.TbPrFamiliaVentaOnline.Include(f => f.InverseIdFamiliaNavigation).FirstOrDefault(f => f.Id == id);
        }

        public IList<TbPrFamiliaVentaOnline> GetAllFamilias()
        {
            return context.TbPrFamiliaVentaOnline.Include(f => f.InverseIdFamiliaNavigation).Where(f => f.IdFamilia == null).ToList();
        }

        public IList<TbPrFamiliaVentaOnline> GetAllSubFamilias()
        {
            return context.TbPrFamiliaVentaOnline.Where(f => f.IdFamilia != null).ToList();
        }

        public TbPrFamiliaVentaOnline GetFamiliaByDescripcion(string descripcion)
        {
            return context.TbPrFamiliaVentaOnline.FirstOrDefault(f => f.Descripcion == descripcion);
        }

        public void UpdateSubFamilia(IList<TbPrFamiliaVentaOnline> subFamilias)
        {
            try
            {
                context.TbPrFamiliaVentaOnline.UpdateRange(subFamilias);
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
