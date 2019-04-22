using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public partial class HistorialMonedaViewModel
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activa { get; set; }
        public DateTime Fecha { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenta { get; set; }
        public string Simbolo { get; set; }


    }
}
