using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class CotizacionMap:ICotizacionMap
    {
        private readonly ICotizacionService _Service;

        public CotizacionMap(ICotizacionService service)
        {
            this._Service = service;
           
        }


    }
}
