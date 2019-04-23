using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSeContactosCamposPersonalizados
    {
        public long Id { get; set; }
        public long? IdContacto { get; set; }
        public long? IdCampoPersonalizados { get; set; }

        public virtual TbSeCamposPersonalizados IdCampoPersonalizadosNavigation { get; set; }
        public virtual TbSeContacto IdContactoNavigation { get; set; }
    }
}
