using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaCajaArqueoOperadorTarjeta
    {
        public long IdCajaArqueoOperadorTarjeta { get; set; }
        public long IdFlujoCategoria { get; set; }
        public long IdCaja { get; set; }
        public string NumeroCierre { get; set; }

        public virtual TbFaCaja IdCajaNavigation { get; set; }
        public virtual TbBaFlujoCategoria IdFlujoCategoriaNavigation { get; set; }
    }
}
