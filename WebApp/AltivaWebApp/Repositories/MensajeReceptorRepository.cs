using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
namespace AltivaWebApp.Repositories
{
    public class MensajeReceptorRepository : BaseRepositoryGE<TbSeMensajeReceptor>, IMensajeReceptorRepository
    {
        public MensajeReceptorRepository(GrupoEmpresarialContext context) : base(context)
        {
        }
        public void Crear(List<TbSeMensajeReceptor> mensajeReceptor)
        {
            context.TbSeMensajeReceptor.AddRange(mensajeReceptor);
            context.SaveChanges();

        }
        public TbSeMensajeReceptor Consultar(int id)
        {
            return this.context.TbSeMensajeReceptor.SingleOrDefault(u => u.Id == id);
        }
    }
}
