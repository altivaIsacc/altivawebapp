using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbReDescarga
    {
        public TbReDescarga()
        {
            TbReDescargaDetalle = new HashSet<TbReDescargaDetalle>();
        }

        public int IdDescarga { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int IdUsuarioModificador { get; set; }
        public double CostoTotal { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public double PorcentajeDesperdicio { get; set; }
        public double PorcentajeEspecies { get; set; }
        public int Porciones { get; set; }

        public virtual ICollection<TbReDescargaDetalle> TbReDescargaDetalle { get; set; }
    }
}
