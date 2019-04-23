using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSeCamposPersonalizados
    {
        public TbSeCamposPersonalizados()
        {
            TbSeContactosCamposPersonalizados = new HashSet<TbSeContactosCamposPersonalizados>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }

        public virtual ICollection<TbSeContactosCamposPersonalizados> TbSeContactosCamposPersonalizados { get; set; }
    }
}
