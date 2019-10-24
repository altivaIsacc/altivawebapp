using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbBaFlujo
    {
        public long IdFlujo { get; set; }
        public bool Debito { get; set; }
        public long IdCategoriaFlujo { get; set; }
        public int IdTipo { get; set; }
        public int? IdUsuario { get; set; }
        public long Documento { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaMod { get; set; }

        public virtual TbBaFlujoCategoria IdCategoriaFlujoNavigation { get; set; }
    }
}
