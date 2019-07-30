using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    interface ICajaAperturaDenominacionService
    {
        IList<TbFaCajaAperturaDenominacion> GetAll();
    }
}
