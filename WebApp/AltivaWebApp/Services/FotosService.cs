using Microsoft.AspNetCore.Hosting.Internal;
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
        public static string SubirFotoUsuario(IFormFile file)
        {
                if (file.Length > 0)
                {
                var fileName = GetUniqueName(file.FileName);
                var path = $"wwwroot\\uploads\\{fileName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }

                return $"/uploads/{fileName}";
            }
                else
                    return "/avatars/ninja.png";
                                             
        }
        public static string SubirFotoContacto(IFormFile file)
        {
            var ruta = "";
            if (file.Length > 0)
            {
                var fileName = GetUniqueName(file.FileName);
                var path = $"wwwroot\\uploads\\{fileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                ruta= $"/uploads/{fileName}";
            }
            return ruta;

        }
        public static string SubirFotoEmpresa(IFormFile file)
        {
                if (file.Length > 0)
                {
                    var fileName = GetUniqueName(file.FileName);

                var path = $"wwwroot\\uploads\\{fileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return $"/uploads/{fileName}";
                }
                else 
                   return "/avatars/ninja.png";                   
                

                      
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
