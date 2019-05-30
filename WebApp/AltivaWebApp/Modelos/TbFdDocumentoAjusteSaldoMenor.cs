using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdDocumentoAjusteSaldoMenor
    {
        public long Id { get; set; }
        public long IdAjusteSaldoMenor { get; set; }
        public string TipoDocumento { get; set; }
        public long IdDocumento { get; set; }
        public string Cliente { get; set; }
        public double Saldo { get; set; }
        public DateTime FechaDocumento { get; set; }

        public virtual TbFdAjusteSaldoMenor IdAjusteSaldoMenorNavigation { get; set; }
        public virtual TbFdNotasDebito IdDocumento1 { get; set; }
        public virtual TbFdFacturacion IdDocumentoNavigation { get; set; }
    }
}
