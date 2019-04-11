using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace AltivaWebApp.Context
{
    public class ContextFactory
    {     

        public static void CrearContext(string grupo)
        {
                       

            var conf = new ConfigurationBuilder()
            .SetBasePath(Startup.entorno.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();

           

            if(StringFactory.StringGE == null)
            {               
                StringFactory.SetStringGE(grupo);
            }


            

        }
    }
}
