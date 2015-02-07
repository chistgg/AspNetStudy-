using MvcApplication3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Areas.Default.Controllers
{
    public class RoleController : BaseController
    {
        //
        // GET: /Role/

        public ActionResult Role()
        {
            var roles = RepositoryRole.Roles.ToList();
            return View(roles);
        }

    }
}
