using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaMovimientoJustificante
    {
        public long IdMovimientoJustificante { get; set; }
        public long IdMovimiento { get; set; }
        public long IdTipoJustificante { get; set; }
        public long IdUsuario { get; set; }
        public int Estado { get; set; }
        public int IdMoneda { get; set; }
        public double MontoBase { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public double CompraDolarTc { get; set; }
        public double VentaDolatTc { get; set; }
        public double CompraEuroTc { get; set; }
        public double VentaEuroTc { get; set; }
        public string Descripcion { get; set; }

        public virtual TbFaMovimiento IdMovimientoNavigation { get; set; }
        public virtual TbFaTipoJustificante IdTipoJustificanteNavigation { get; set; }
    }
}
