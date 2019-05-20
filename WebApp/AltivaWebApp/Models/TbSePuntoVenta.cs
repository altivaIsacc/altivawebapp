using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSePuntoVenta
    {
        public TbSePuntoVenta()
        {
            TbFdCuentaEnCasaPuntoDeVenta = new HashSet<TbFdCuentaEnCasaPuntoDeVenta>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Inactivo { get; set; }
        public string Tipo { get; set; }
        public string RazonSocial { get; set; }
        public string CedulaJuridica { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Web { get; set; }
        public byte[] Logo { get; set; }
        public int IdMonedaPrecio { get; set; }
        public int IdMonedaFacturaDefecto { get; set; }

        public virtual ICollection<TbFdCuentaEnCasaPuntoDeVenta> TbFdCuentaEnCasaPuntoDeVenta { get; set; }
    }
}
