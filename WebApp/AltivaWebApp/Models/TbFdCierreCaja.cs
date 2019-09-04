using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdCierreCaja
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdApertura { get; set; }
        public long IdArqueo { get; set; }
        public double MontoApertura { get; set; }
        public double MontoArqueo { get; set; }
        public double SumaFormaPago { get; set; }
        public double Diferencia { get; set; }
        public bool Anulado { get; set; }
        public string Nota { get; set; }
        public double MontoAperturaDolar { get; set; }
        public double MontoAperturaEuro { get; set; }
        public double MontoArqueoDolar { get; set; }
        public double MontoArqueoEuro { get; set; }
        public double SumaFormaDolar { get; set; }
        public double SumaFormaEuro { get; set; }
        public double SumaFormaColon { get; set; }
        public double DiferenciaDolar { get; set; }
        public double DiferenciaEuro { get; set; }
        public double DiferenciaColon { get; set; }
        public double MontoAperturaColon { get; set; }
        public double MontoArqueoColon { get; set; }

        public virtual TbFdAperturaCaja IdAperturaNavigation { get; set; }
        public virtual TbFdArqueoCaja IdArqueoNavigation { get; set; }
    }
}
