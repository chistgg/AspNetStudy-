using MvcApplication3.Mappers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Controllers
{
    public abstract class BaseController : Controller
    {
        //
        // GET: /Base/
        [Inject]
        public IRepositoryRole RepositoryRole { get; set; }

        [Inject]
        public IRepositoryUser RepositoryUser { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }
    }
}
