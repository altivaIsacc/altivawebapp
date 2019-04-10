using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using System.IO;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.ViewModels.Components.Avatar
{
    public class Avatar : ViewComponent
    {
        IUserMap _userMap;
        public Avatar(IUserMap userMap)
        {
            this._userMap = userMap;
        }
        public IViewComponentResult Invoke( TbSeUsuario model)
        {
            ViewData["avatares"] = Avatars();
            var viewModel =_userMap.DomainToViewModelSingle(model);
            return View(viewModel);
        }
        public IList<string> Avatars()
        {
            IList<string> avatars;
            string directorio = $"wwwroot\\avatars\\";
            avatars = Directory.GetFiles(directorio).Select(f => System.IO.Path.GetFileName(f)).ToList();
            return avatars;
        }
    }
}