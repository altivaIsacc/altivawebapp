using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdTemporadaGrupo
    {
        public TbFdTemporadaGrupo()
        {
            TbFdTemporada = new HashSet<TbFdTemporada>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Inactivo { get; set; }
        public bool General { get; set; }

        public virtual ICollection<TbFdTemporada> TbFdTemporada { get; set; }
    }
}
