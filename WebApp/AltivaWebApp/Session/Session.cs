
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Session
{
    public static class Session
    {
        public static string _KEYBDGE = "stringGE";
        public static string _KEYBDBE = "stringBE";
        public static string _KEYnombreUsuario = "nombreUsuario";
        public static string _KEYIdEmpresa = "idEmpresa";

        public static void SetStringGE(this ISession session, string value)
        {
            session.SetString(_KEYBDGE, value);
        }
        public static void SetStringBE(this ISession session, string value)
        {
            session.SetString(_KEYBDBE, value);
        }
        public static void SetNombreUsuario(this ISession session, string value)
        {
            session.SetString(_KEYnombreUsuario, value);
        }
        public static void SetIdEmpresa(this ISession session, int value)
        {
            session.SetInt32(_KEYIdEmpresa, value);
        }

    }
}
