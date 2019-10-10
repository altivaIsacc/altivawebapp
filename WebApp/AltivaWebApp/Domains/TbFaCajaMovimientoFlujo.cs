using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaCajaMovimientoFlujo
    {
        public long IdCajaMovimientoFlujo { get; set; }
        public long IdFlujo { get; set; }
        public long IdCajaMovimiento { get; set; }

        public virtual TbFaCajaMovimiento IdCajaMovimientoNavigation { get; set; }
        public virtual TbBaFlujo IdFlujoNavigation { get; set; }
    }
}
