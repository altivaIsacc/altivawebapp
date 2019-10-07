using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaCaja
    {
        public TbFaCaja()
        {
            TbFaCajaAperturaDenominacion = new HashSet<TbFaCajaAperturaDenominacion>();
            TbFaCajaArqueo = new HashSet<TbFaCajaArqueo>();
            TbFaCajaArqueoDenominacion = new HashSet<TbFaCajaArqueoDenominacion>();
            TbFaCajaArqueoOperadorTarjeta = new HashSet<TbFaCajaArqueoOperadorTarjeta>();
            TbFaCajaCierre = new HashSet<TbFaCajaCierre>();
            TbFaCajaMovimiento = new HashSet<TbFaCajaMovimiento>();
        }

        public long IdCaja { get; set; }
        public long IdPuntoVenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual TbSePuntoVenta IdPuntoVentaNavigation { get; set; }
        public virtual ICollection<TbFaCajaAperturaDenominacion> TbFaCajaAperturaDenominacion { get; set; }
        public virtual ICollection<TbFaCajaArqueo> TbFaCajaArqueo { get; set; }
        public virtual ICollection<TbFaCajaArqueoDenominacion> TbFaCajaArqueoDenominacion { get; set; }
        public virtual ICollection<TbFaCajaArqueoOperadorTarjeta> TbFaCajaArqueoOperadorTarjeta { get; set; }
        public virtual ICollection<TbFaCajaCierre> TbFaCajaCierre { get; set; }
        public virtual ICollection<TbFaCajaMovimiento> TbFaCajaMovimiento { get; set; }
    }
}
