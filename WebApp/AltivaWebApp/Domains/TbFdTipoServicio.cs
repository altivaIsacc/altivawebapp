using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdTipoServicio
    {
        public TbFdTipoServicio()
        {
            TbFdAuditoriaIngresos = new HashSet<TbFdAuditoriaIngresos>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public string IdCuentaContable { get; set; }
        public bool Inactivo { get; set; }
        public string NombreCuenta { get; set; }

        public virtual ICollection<TbFdAuditoriaIngresos> TbFdAuditoriaIngresos { get; set; }
    }
}
