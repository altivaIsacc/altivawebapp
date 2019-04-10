using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdTemporada
    {
        public TbFdTemporada()
        {
            TbFdContratoServicio = new HashSet<TbFdContratoServicio>();
            TbFdTemporadaRango = new HashSet<TbFdTemporadaRango>();
        }

        public long Id { get; set; }
        public long IdGrupoTemporadas { get; set; }
        public string Nombre { get; set; }
        public bool Inactivo { get; set; }

        public virtual TbFdTemporadaGrupo IdGrupoTemporadasNavigation { get; set; }
        public virtual ICollection<TbFdContratoServicio> TbFdContratoServicio { get; set; }
        public virtual ICollection<TbFdTemporadaRango> TbFdTemporadaRango { get; set; }
    }
}
