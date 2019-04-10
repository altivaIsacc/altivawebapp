using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCrListaDesplegables
    {
        public long Id { get; set; }
        public long? IdCamposPersonalizados { get; set; }
        public string Valor { get; set; }

        public virtual TbCrCamposPersonalizados IdCamposPersonalizadosNavigation { get; set; }
    }
}
