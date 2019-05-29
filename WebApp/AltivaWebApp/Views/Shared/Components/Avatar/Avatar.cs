using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using System.IO;
using AltivaWebApp.GEDomain;
using Microsoft.AspNetCore.Hosting;

namespace AltivaWebApp.ViewModels.Components.Avatar
{
    public class Avatar : ViewComponent
    {
        IUserMap _userMap;
        private readonly IHostingEnvironment hostingEnvironment;

        public Avatar(IUserMap userMap, IHostingEnvironment hostingEnvironment)
        {
            this._userMap = userMap;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IViewComponentResult Invoke( UsuarioViewModel model)
        {
            ViewData["avatares"] = Avatars();
            //var viewModel =_userMap.DomainToViewModelSingle(model);
            return View(model);
        }
        public IList<string> Avatars()
        {
            IList<string> avatars;
            //string directorio = $"wwwroot\\avatars\\";
            string directorio = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "avatars");

            avatars = Directory.GetFiles(directorio).Select(f => System.IO.Path.GetFileName(f)).ToList();
            return avatars;
        }
    }
}