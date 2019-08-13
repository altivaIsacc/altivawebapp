using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrAjustesInventario
    {
        public int IdAjusteInventario { get; set; }
        public int IdAjuste { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Justificacion { get; set; }
        public bool Movimiento { get; set; }
        public double Cantidad { get; set; }
        public double PrecioCompra { get; set; }
        public double CostoMovimiento { get; set; }
        public long IdBodega { get; set; }
        public long IdInventario { get; set; }
    }
}
