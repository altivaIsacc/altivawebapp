using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdContratoTipoTarifa
    {
        public long Id { get; set; }
        public long IdContrato { get; set; }
        public long IdTipoTarifa { get; set; }

        public virtual TbFdContrato IdContratoNavigation { get; set; }
        public virtual TbFdTipoTarifa IdTipoTarifaNavigation { get; set; }
    }
}
