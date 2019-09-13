using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaMovimiento
    {
        public TbFaMovimiento()
        {
            TbFaCajaMovimiento = new HashSet<TbFaCajaMovimiento>();
            TbFaMovimientoDetalleIdMovimientoDesdeNavigation = new HashSet<TbFaMovimientoDetalle>();
            TbFaMovimientoDetalleIdMovimientoHastaNavigation = new HashSet<TbFaMovimientoDetalle>();
            TbFaMovimientoJustificante = new HashSet<TbFaMovimientoJustificante>();
        }

        public long IdMovimiento { get; set; }
        public long IdContacto { get; set; }
        public long IdDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public long? IdUsuario { get; set; }
        public bool Cxp { get; set; }
        public bool Cxc { get; set; }
        public int IdMoneda { get; set; }
        public double Monto { get; set; }
        public double Disponible { get; set; }
        public double Aplicado { get; set; }
        public double Saldo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual TbCrContacto IdContactoNavigation { get; set; }
        public virtual TbFaTipoDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<TbFaCajaMovimiento> TbFaCajaMovimiento { get; set; }
        public virtual ICollection<TbFaMovimientoDetalle> TbFaMovimientoDetalleIdMovimientoDesdeNavigation { get; set; }
        public virtual ICollection<TbFaMovimientoDetalle> TbFaMovimientoDetalleIdMovimientoHastaNavigation { get; set; }
        public virtual ICollection<TbFaMovimientoJustificante> TbFaMovimientoJustificante { get; set; }
    }
}
