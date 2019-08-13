using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AltivaWebApp.Repositories
{
   public interface ICajaAperturaDenominacionRepository
    {
        IList<TbFaCajaAperturaDenominacion> GetAll();
    }
}
