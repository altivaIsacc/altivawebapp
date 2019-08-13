using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TrasladoInventarioViewModel
    {
        public long Id { get; set; }
        public long IdTraslado { get; set; }
        public long IdInventario { get; set; }
        public string CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double CostoTotal { get; set; }

    }
}
