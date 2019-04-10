using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdJustificante
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public long IdNota { get; set; }
        public string TipoNota { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMoneda { get; set; }
        public double? Conversion { get; set; }
        public long? IdAperturaCaja { get; set; }
        public int? IdUsuario { get; set; }
        public long IdCuentaContable { get; set; }

        public virtual TbFdAperturaCaja IdAperturaCajaNavigation { get; set; }
        public virtual TbFdNotasDebito IdNota1 { get; set; }
        public virtual TbFdNotasCredito IdNotaNavigation { get; set; }
    }
}
