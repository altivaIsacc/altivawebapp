using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdHistoricoCuentasPorCobrar
    {
        public int Id { get; set; }
        public long IdCliente { get; set; }
        public long IdDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime Fecha { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuaUltimo { get; set; }
        public decimal Monto { get; set; }
        public decimal Aplicado { get; set; }
        public decimal Pendiente { get; set; }
        public long Anulado { get; set; }
    }
}
