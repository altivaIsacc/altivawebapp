using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class DenominacionRepository:BaseRepository<TbFaDenominacion>, IDenominacionRepository
    {
        public DenominacionRepository(EmpresasContext context) : base(context)
        {

        }

        public IList<TbFaDenominacion> GetAllDenominaciones()
        {
            try
            {
                return context.TbFaDenominacion.ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public TbFaDenominacion GetDenominacionesById(int id)
        {
            try
            {
                return context.TbFaDenominacion.FirstOrDefault(c => c.IdDenominaciones==id);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }


    }
}
