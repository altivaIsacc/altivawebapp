using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class AjusteInventarioViewModel
    {
        public long Id { get; set; }
        public long IdAjuste { get; set; }
        public long IdInventario { get; set; }
        public string Descripcion { get; set; }
        public bool Movimiento { get; set; }
        public double Cantidad { get; set; }
        public double CostoPromedio { get; set; }
        public double TotalMovimiento { get; set; }
        public long IdCuentaContable { get; set; }
        public long IdCentroGastos { get; set; }
    }
}
