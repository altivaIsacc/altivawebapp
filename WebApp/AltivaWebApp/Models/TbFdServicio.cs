using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdServicio
    {
        public TbFdServicio()
        {
            TbFdAuditoriaIngresos = new HashSet<TbFdAuditoriaIngresos>();
            TbFdContratoServicio = new HashSet<TbFdContratoServicio>();
            TbFdContratoServicioTemp = new HashSet<TbFdContratoServicioTemp>();
            TbFdCuentaDetalleServicioTarifa = new HashSet<TbFdCuentaDetalleServicioTarifa>();
            TbFdReservacionServicio = new HashSet<TbFdReservacionServicio>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long TipoServicio { get; set; }
        public bool Inactivo { get; set; }
        public double TarifaBase { get; set; }
        public bool ImpuestoVenta { get; set; }
        public bool ImpuestoServicio { get; set; }
        public bool CambiarDescripcion { get; set; }
        public bool CambiarPrecio { get; set; }
        public double Total { get; set; }

        public virtual ICollection<TbFdAuditoriaIngresos> TbFdAuditoriaIngresos { get; set; }
        public virtual ICollection<TbFdContratoServicio> TbFdContratoServicio { get; set; }
        public virtual ICollection<TbFdContratoServicioTemp> TbFdContratoServicioTemp { get; set; }
        public virtual ICollection<TbFdCuentaDetalleServicioTarifa> TbFdCuentaDetalleServicioTarifa { get; set; }
        public virtual ICollection<TbFdReservacionServicio> TbFdReservacionServicio { get; set; }
    }
}
