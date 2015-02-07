using MvcApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace MvcApplication3
{
    public partial class SqlRepository : IRepositoryRole
    {

        public  IQueryable<Role> Roles
        {
            get
            {
                return Db.Roles;
            }
        }

        public  bool UpdateRole(Role instance)
        {
            Role cache = Db.Roles.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Table
                Db.Roles.Context.SubmitChanges();
                return true;
            }

            return false;
        }
        public  bool CreateRole(Role instance)
        {
            if (instance.ID == 0)
            {
                Db.Roles.InsertOnSubmit(instance);
                Db.Roles.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public  bool RemoveRole(int idRole)
        {
            Role instance = Db.Roles.FirstOrDefault(p => p.ID == idRole);
            if (instance != null)
            {
                Db.Roles.DeleteOnSubmit(instance);
                Db.Roles.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }

}