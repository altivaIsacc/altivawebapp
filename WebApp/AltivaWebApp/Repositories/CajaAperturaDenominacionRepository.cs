using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class CajaAperturaDenominacionRepository: BaseRepository<TbFaCajaAperturaDenominacion>, ICajaAperturaDenominacionRepository
    {
        public CajaAperturaDenominacionRepository(EmpresasContext context) : base(context)
        {

        }
    }
}
