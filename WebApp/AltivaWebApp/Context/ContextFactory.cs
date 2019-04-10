using Microsoft.Extensions.Configuration;
using System.IO;


namespace AltivaWebApp.Context
{
    public class ContextFactory
    {     

        public static void CrearContext(string grupo)
        {
            
            

            var conf = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

           

            if(StringFactory.StringGE == null)
            {               
                StringFactory.SetStringGE(grupo);
            }


            

        }
    }
}
