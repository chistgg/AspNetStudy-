using MvcApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3
{
    public interface IRepositoryUser
    {
        IQueryable<MvcApplication3.Models.User> Users { get; }

        bool CreateUser(MvcApplication3.Models.User instance);

        bool UpdateUser(MvcApplication3.Models.User instance);

        bool RemoveUser(int idUser);
    }
}