using MvcApplication3.Controllers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Areas.Default.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            var cookie = new HttpCookie("test_cookie")
            {
                Name = "test_cookie",
                Value = DateTime.Now.ToString("dd.MM.yyyy"),
                Expires = DateTime.Now.AddMinutes(10),
            };
            Response.SetCookie(cookie);
            return View();
           // var roles = RepositoryRole.Roles.ToList();
          //  return View(roles);
        }

      

    }
}
