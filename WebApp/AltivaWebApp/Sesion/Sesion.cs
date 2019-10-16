
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace AltivaWebApp.Sesion
{
    public static class Sesion
    {
        public static string _KEYBDGE = "stringGE";
        public static string _KEYBDBE = "stringBE";
        public static string _KEYnombreUsuario = "nombreUsuario";
        public static string _KEYidUsuario = "IdUsuario";
        public static string _KEYIdEmpresa = "idEmpresa";
        public static string _KEYIdiomaUsuario = "idioma";
        public static string _KEYAvatar = "avatar";
        public static string _KEYFotoEmpresa = "fotoEmpresa";
        public static string _KEYNombreEmpresa = "nombreEmpresa";

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
        public static void SetIdioma(this ISession session, string value)
        {
            session.SetString(_KEYIdiomaUsuario, value);
        }

        public static void SetAvatar(this ISession session, string value)
        {
            session.SetString(_KEYAvatar, value);
        }

        public static void SetFotoEmpresa(this ISession session, string value)
        {
            session.SetString(_KEYFotoEmpresa, value);
        }
        public static void SetNombreEmpresa(this ISession session, string value)
        {
            session.SetString(_KEYNombreEmpresa, value);
        }
    }
}
