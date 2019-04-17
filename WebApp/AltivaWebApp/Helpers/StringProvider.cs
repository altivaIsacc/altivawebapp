using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Helpers
{
    public static class StringProvider
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static String StringGE => _httpContextAccessor.HttpContext.Session.GetString("StringGE");

        public static String StringEmpresas => _httpContextAccessor.HttpContext.Session.GetString("StringEmpresas");

    }
}
