using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaCajaMovimientoCheque
    {
        public long IdCajaMovimientoCheque { get; set; }
        public long IdCajaMovimiento { get; set; }
        public long Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Banco { get; set; }
        public string Nota { get; set; }
        public string Portador { get; set; }

        public virtual TbFaCajaMovimiento IdCajaMovimientoNavigation { get; set; }
    }
}
