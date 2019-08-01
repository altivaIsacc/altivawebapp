using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaCotizacionConfig
    {
        public int IdCotizacionConfig { get; set; }
        public long? IdClienteDefecto { get; set; }
        public int? IdMonedaDefecto { get; set; }
        public int? DiasVenceDefecto { get; set; }
    }
}
