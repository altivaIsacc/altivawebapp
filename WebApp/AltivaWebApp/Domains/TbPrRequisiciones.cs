using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrRequisiciones
    {
        public TbPrRequisiciones()
        {
            TbPrRequisicionInventario = new HashSet<TbPrRequisicionInventario>();
        }

        public long IdRequisicion { get; set; }
        public long IdUsuario { get; set; }
        public long IdDepartamento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Justificacion { get; set; }
        public double CostoRequisicion { get; set; }
        public bool? Inactivo { get; set; }
        public DateTime Fecha { get; set; }

        public virtual TbPrDepartamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<TbPrRequisicionInventario> TbPrRequisicionInventario { get; set; }
    }
}
