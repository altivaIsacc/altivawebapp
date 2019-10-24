using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CatalogoContableViewModel
    {     
        public long IdCuentaContable { get; set; }
        public string CuentaContable { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }
        public short Nivel { get; set; }
        public short IdTipoCuentaContable { get; set; }
        public long IdCuentaContablePadre { get; set; }
        public string CuentaContablePadre { get; set; }
        public string DescCuentaPadre { get; set; }
        public bool Movimiento { get; set; }
        public long IdCuentaPresupuesto { get; set; }
        public bool Evaluacion { get; set; }
        public int IdMonedaEvaluacion { get; set; }
        public int IdTipoConversion { get; set; }
        public bool Inactivo { get; set; }
    }
}
