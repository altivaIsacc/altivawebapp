using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdAuditoriaIngresos
    {
        public long Id { get; set; }
        public long IdAuditoria { get; set; }
        public long IdServicio { get; set; }
        public long IdTipoServicio { get; set; }
        public long IdCliente { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public DateTime Dia { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public double Total { get; set; }
        public string Tipo { get; set; }
        public string Habitacion { get; set; }
        public long IdReservacion { get; set; }
        public string Moneda { get; set; }
        public long IdFactura { get; set; }

        public virtual TbFdCliente IdClienteNavigation { get; set; }
        public virtual TbFdServicio IdServicioNavigation { get; set; }
        public virtual TbFdTipoServicio IdTipoServicioNavigation { get; set; }
    }
}
