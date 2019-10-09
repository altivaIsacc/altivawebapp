using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    //creada por lenin
  
    public partial class TbBaFlujoCategoria
    {
        public TbBaFlujoCategoria()
        {
            TbBaFlujo = new HashSet<TbBaFlujo>();
            TbFaCajaArqueoOperadorTarjeta = new HashSet<TbFaCajaArqueoOperadorTarjeta>();
            TbFaCajaMovimiento = new HashSet<TbFaCajaMovimiento>();
        }

        public long IdCategoriaFlujo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public int IdTipoFlujo { get; set; }
        public int IdMoneda { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<TbBaFlujo> TbBaFlujo { get; set; }
        public virtual ICollection<TbFaCajaArqueoOperadorTarjeta> TbFaCajaArqueoOperadorTarjeta { get; set; }
        public virtual ICollection<TbFaCajaMovimiento> TbFaCajaMovimiento { get; set; }
    }
}
