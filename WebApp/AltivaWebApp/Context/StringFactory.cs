using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace AltivaWebApp.Context
{
    public class StringFactory

    {
        public static string StringGE;

        public static string StringEmpresas;


        public static void SetStringGE(string grupo)
        {
            var conf = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();


            var server = conf["server"];

            var pass = conf["serverPassword"];

            var user = conf["serverUser"];

            StringGE = "Data source=" + server + ";" + "Initial Catalog=" + "GE_" + grupo + ";" + "User Id=" +user + ";Password=" + pass + ";";

        }


        public static void SetStringEmpresas(string empresa)
        {
            var conf = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            var server = conf["server"];

            var pass = conf["serverPassword"];

            var user = conf["serverUser"];

            StringEmpresas = "Data source=" + server + ";" + "Initial Catalog=" + empresa + ";" + "User Id=" + user + ";Password=" + pass + ";";



        }
       

    }
}
