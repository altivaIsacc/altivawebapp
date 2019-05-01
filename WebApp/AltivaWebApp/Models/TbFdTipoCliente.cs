using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdTipoCliente
    {
        public TbFdTipoCliente()
        {
            TbFdCliente = new HashSet<TbFdCliente>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Inactivo { get; set; }
        public int IdCuentaContableCre { get; set; }
        public int IdCuentaContablePre { get; set; }
        public string CuentaContable { get; set; }
        public string NombreCuenta { get; set; }

        public virtual ICollection<TbFdCliente> TbFdCliente { get; set; }
    }
}
