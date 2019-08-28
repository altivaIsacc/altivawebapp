using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AltivaWebApp.Resources
{
    public static class JsonStringProvider
    {

        public static string GetJson(string cultura)
        {
            var pathJson = System.IO.Path.Combine(Startup.entorno.ContentRootPath, @".\Resources\Idioma-" + cultura + ".json");

            

            if (!File.Exists(pathJson))
            {

                var idioma = @".\Resources\SharedResources." + cultura + ".resx";

                var ruta = System.IO.Path.Combine(Startup.entorno.ContentRootPath, idioma);

                var xml = File.ReadAllText(ruta);



                var Texts = XElement.Parse(xml)
                    .Elements("data")
                    .Select(el => new
                    {
                        key = el.Attribute("name").Value,
                        value = el.Element("value").Value.Trim()
                    })
                    .ToList();

                var json = "{\n";

                int cont = 1;

                foreach (var item in Texts)
                {
                    json += $"\"{item.key}\":\"{item.value}\"";
                    if (Texts.Count() > cont)
                        json += ",\n";

                    cont++;
                }

                json += "\n}";

                string rutaJson = System.IO.Path.Combine(Startup.entorno.ContentRootPath, "Resources");

                string archivo = System.IO.Path.Combine(rutaJson, @".\Idioma-" + cultura + ".json");
                System.IO.File.WriteAllText(archivo, json);


            }

            return $"Json={pathJson}";


        }

    }
}
