using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AltivaWebApp.Repositories
{
    public class NotaRepository: BaseRepository<TbFaNota>, INotaRepository
    {
        public NotaRepository(EmpresasContext context) : base(context)
        {

        }
        public TbFaNota GetNotaById(long id)
        {
            return context.TbFaNota.FirstOrDefault(d => d.IdNotaCredito == id);
        }
        public IList<TbFaTipoDocumento> GetAllTipoDocumento()
        {
            return context.TbFaTipoDocumento.Where(t => t.EsNota == true).ToList();
        }
        public TbFaMovimiento SaveMovimiento(TbFaMovimiento domain)
        {
            try
            {
                context.TbFaMovimiento.Add(domain);
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
