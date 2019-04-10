using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ListaDesplegableGETViewModel
    {
        public int IdCampoPersonalizado { get; set; }
        public int IdListaDesplegable { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }

        public ListaDesplegableGETViewModel()
        {
            Nombre = "";
            Tipo = "";
            Valor = "";
        }
    }
}
