using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdHistoricoCuentaPorPagar
    {
        public long Id { get; set; }
        public long IdDocumentoCxc { get; set; }
        public string TipoDocumentoCxc { get; set; }
        public long IdDocumentoCxp { get; set; }
        public string TipoDocuementoCxp { get; set; }
        public decimal MontoAplicado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioUltimo { get; set; }
        public long Anulado { get; set; }
    }
}
