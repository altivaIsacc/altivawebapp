using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AltivaWebApp.Context
{
    public class StringFactory

    {
        public static string StringGE;

        public static string StringEmpresas;

        public static string _StringEmpresas = "StringEmpresas";
        public static string _StringGE = "StringGE";

        public static void SetStringGE(ISession session, string grupo)
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Startup.entorno.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();        
   

            var server = conf["server"];

            var pass = conf["serverPassword"];

            var user = conf["serverUser"];

            StringGE = "Data source=" + server + ";" + "Initial Catalog=" + "GE_" + grupo + ";" + "User Id=" +user + ";Password=" + pass + ";";

            session.SetString(_StringGE, "Data source=" + server + ";" + "Initial Catalog=" + "GE_" + grupo + ";" + "User Id=" + user + ";Password=" + pass + ";");
        }


        public static void SetStringEmpresas(ISession session, string empresa)
        {
            var conf = new ConfigurationBuilder()
              .SetBasePath(Startup.entorno.ContentRootPath)
          .AddJsonFile("appsettings.json").Build();

            var server = conf["server"];

            var pass = conf["serverPassword"];

            var user = conf["serverUser"];

            StringEmpresas = "Data source=" + server + ";" + "Initial Catalog=" + empresa + ";" + "User Id=" + user + ";Password=" + pass + ";";

            session.SetString(_StringEmpresas, "Data source=" + server + ";" + "Initial Catalog=" + empresa + ";" + "User Id=" + user + ";Password=" + pass + ";");

        }
       

    }
}
