using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCrContactosCamposPersonalizados
    {
        public long Id { get; set; }
        public long IdContacto { get; set; }
        public long IdCampoPersonalizados { get; set; }
        public string Valor { get; set; }

        public virtual TbCrCamposPersonalizados IdCampoPersonalizadosNavigation { get; set; }
        public virtual TbCrContacto IdContactoNavigation { get; set; }
    }
}
