using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCrCamposPersonalizados
    {
        public TbCrCamposPersonalizados()
        {
            TbCrContactosCamposPersonalizados = new HashSet<TbCrContactosCamposPersonalizados>();
            TbCrListaDesplegables = new HashSet<TbCrListaDesplegables>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<TbCrContactosCamposPersonalizados> TbCrContactosCamposPersonalizados { get; set; }
        public virtual ICollection<TbCrListaDesplegables> TbCrListaDesplegables { get; set; }
    }
}
