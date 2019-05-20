using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCoParamentrosDeRenta
    {
        public long Id { get; set; }
        public double Porc1 { get; set; }
        public double Porc2 { get; set; }
        public double Porc3 { get; set; }
        public double Monto1Colones { get; set; }
        public double Monto1Dolar { get; set; }
        public double Monto1Euro { get; set; }
        public double Monto2Colones { get; set; }
        public double Monto2Dolar { get; set; }
        public double Monto2Euro { get; set; }
        public double Monto3Colones { get; set; }
        public double Monto3Dolar { get; set; }
        public double Monto3Euro { get; set; }
        public double Tpccd { get; set; }
        public double Tpcvd { get; set; }
        public double Tpcce { get; set; }
        public double Tpcve { get; set; }
        public long IdMoneda { get; set; }
    }
}
