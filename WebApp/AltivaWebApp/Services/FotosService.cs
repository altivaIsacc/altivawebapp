﻿using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class FotosService
    {
        public static string SubirFotoUsuarios1(IFormFile file, string savePath)
        {
            if (file != null)
            {
                    var fileName = GetUniqueName(file.FileName);
                //var path = $"wwwroot\\uploads\\{fileName}";
                var path = $"{savePath}\\{fileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return $"/uploads/{fileName}";
                
            }
            else
            {
                return "/avatars/ninja.png";
            }
           
        }
        public static string SubirFotoUsuario(IFormFile file, string savePath)
        {

                if (file.Length > 0)
                {
                var fileName = GetUniqueName(file.FileName);
                //var path = $"wwwroot\\uploads\\{fileName}";
                var path = $"{savePath}\\{fileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                return $"/uploads/{fileName}";
            }
                else
                    return "/avatars/ninja.png";
                                             
        }
        public static string SubirFotoContacto(IFormFile file, string savePath)
        {
            var ruta = "";
            if (file.Length > 0)
            {
                var fileName = GetUniqueName(file.FileName);
                var path = $"{savePath}\\{fileName}";

              //  var path = $"wwwroot\\uploads\\{fileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                ruta= $"/uploads/{fileName}";
            }
            return ruta;

        }
        public static string SubirImagenPuntoVenta(IFormFile file, string savePath)
        {
            var ruta = "";
            if (file.Length > 0)
            {
                var fileName = GetUniqueName(file.FileName);
                var path = $"{savePath}\\{fileName}";

                //  var path = $"wwwroot\\uploads\\{fileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                ruta = $"/uploads/{fileName}";
            }
            return ruta;

        }
        public static string SubirFotoEmpresa(IFormFile file, string savePath )
        {
                if (file.Length > 0)
                {
                    var fileName = GetUniqueName(file.FileName);

                //  var path = $"wwwroot\\uploads\\{fileName}";
                var path = $"{savePath}\\{fileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return $"/uploads/{fileName}";
              // return $"{savePath}\\{fileName}";
                }
                else 
                   return "/avatars/ninja.png";                   
                

                      
        }

        public static IList<string> SubirAdjuntos(IFormFile[] files, string savePath)
        {
            var rutas = new List<string>();
            foreach (var item in files)
            {
                var fileName = GetUniqueName(item.FileName);

                //var path = $"wwwroot\\Files\\{fileName}";
                var path = $"{savePath}\\{fileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    item.CopyTo(stream);

                }

                rutas.Add($"/Files/{fileName}");
                
            }

            return rutas;
        }

        private static string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

    }
}
