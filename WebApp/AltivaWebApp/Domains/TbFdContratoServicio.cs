using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdContratoServicio
    {
        public long Id { get; set; }
        public long IdContrato { get; set; }
        public long IdTipoTarifa { get; set; }
        public long IdServicio { get; set; }
        public long IdTemporada { get; set; }
        public double PrecioSinImp { get; set; }
        public double PrecioConImp { get; set; }

        public virtual TbFdContrato IdContratoNavigation { get; set; }
        public virtual TbFdServicio IdServicioNavigation { get; set; }
        public virtual TbFdTemporada IdTemporadaNavigation { get; set; }
        public virtual TbFdTipoTarifa IdTipoTarifaNavigation { get; set; }
    }
}
