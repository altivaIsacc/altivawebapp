using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdArqueoCaja
    {
        public TbFdArqueoCaja()
        {
            TbFdCierreCaja = new HashSet<TbFdCierreCaja>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdUsuario { get; set; }
        public double MontoArqueo { get; set; }
        public string Notas { get; set; }
        public int IdMoneda { get; set; }
        public long IdApertura { get; set; }
        public bool Anulado { get; set; }
        public double MontoDolarArqueo { get; set; }
        public double MontoEuroArqueo { get; set; }
        public double MontoTotalArqueo { get; set; }
        public double MontoTarjetaColon { get; set; }
        public double MontoTarjetaDolar { get; set; }
        public double MontoTarjetaEuro { get; set; }
        public double MontoEfectivoColon { get; set; }
        public double MontoEfectivoDolar { get; set; }
        public double MontoEfectivoEuro { get; set; }
        public double MontoChequeColon { get; set; }
        public double MontoChequeDolar { get; set; }
        public double MontoChequeEuro { get; set; }
        public double MontoTraColon { get; set; }
        public double MontoTraDolar { get; set; }
        public double MontoTraEuro { get; set; }

        public virtual TbFdAperturaCaja IdAperturaNavigation { get; set; }
        public virtual ICollection<TbFdCierreCaja> TbFdCierreCaja { get; set; }
    }
}
