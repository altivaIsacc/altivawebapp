
using System;
using System.IO;

namespace AltivaLog
{
    public class Log
    {
     
        private static string rutaArchivo;
      
        public Log(String entorno)
        {

            rutaArchivo = entorno;
        }
        /// <summary>
        /// Insertar
        /// </summary>
        /// <param name="Mensaje">El mensaje que quiere guardar</param>
        /// <param name="tipo">Tipos: Error, Info, Advertencia, Test</param>
        public static void Insertar(string Mensaje,string tipo)
        {
            string archivo = Path.Combine(rutaArchivo, "LOG-"+ tipo.ToUpper() + "-" + DateTime.Now.ToString("yyyy-MM-dd++HH-mm-ss") + ".log");           
            System.IO.File.WriteAllText(archivo,Mensaje);
        }
        
    }
}
