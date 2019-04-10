using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdContratoServicioTemp
    {
        public long Id { get; set; }
        public long IdContrato { get; set; }
        public long IdServicio { get; set; }

        public virtual TbFdContrato IdContratoNavigation { get; set; }
        public virtual TbFdServicio IdServicioNavigation { get; set; }
    }
}
