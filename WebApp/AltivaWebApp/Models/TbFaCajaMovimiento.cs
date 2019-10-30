using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaCajaMovimiento
    {
        public TbFaCajaMovimiento()
        {
            TbFaCajaMovimientoCheque = new HashSet<TbFaCajaMovimientoCheque>();
            TbFaCajaMovimientoFlujo = new HashSet<TbFaCajaMovimientoFlujo>();
            TbFaCajaMovimientoTarjeta = new HashSet<TbFaCajaMovimientoTarjeta>();
        }

        public long IdCajaMovimiento { get; set; }
        public long IdCategoriaFlujo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Estado { get; set; }
        public int IdMoneda { get; set; }
        public double MontoBase { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public double CompraDolarTc { get; set; }
        public double VentaDolarTc { get; set; }
        public double CompraEuroTc { get; set; }
        public double VentaEuroTc { get; set; }
        public int? IdTipoCajaMovimiento { get; set; }
        public long IdCaja { get; set; }
        public long IdMovimiento { get; set; }

        public virtual TbFaCaja IdCajaNavigation { get; set; }
        public virtual TbBaFlujoCategoria IdCategoriaFlujoNavigation { get; set; }
        public virtual TbFaMovimiento IdMovimientoNavigation { get; set; }
        public virtual ICollection<TbFaCajaMovimientoCheque> TbFaCajaMovimientoCheque { get; set; }
        public virtual ICollection<TbFaCajaMovimientoFlujo> TbFaCajaMovimientoFlujo { get; set; }
        public virtual ICollection<TbFaCajaMovimientoTarjeta> TbFaCajaMovimientoTarjeta { get; set; }
    }
}
