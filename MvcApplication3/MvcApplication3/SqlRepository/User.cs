using MvcApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace MvcApplication3
{
    public partial class SqlRepository : IRepositoryUser
    {


        public IQueryable<MvcApplication3.Models.User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(MvcApplication3.Models.User instance)
        {
            if (instance.ID != 0)
            {
                Db.Users.InsertOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUser(MvcApplication3.Models.User instance)
        {
            MvcApplication3.Models.User cache = Db.Users.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                cache.Birthdate = instance.Birthdate;
                cache.AvatarPath = instance.AvatarPath;
                cache.Email = instance.Email;
                //TODO : Update fields for Table
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveUser(int idUser)
        {
            MvcApplication3.Models.User instance = Db.Users.Where(p => p.ID == idUser).FirstOrDefault();
            if (instance != null)
            {
                Db.Users.DeleteOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }
        
    }
}