using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using MvcApplication3.Models;

namespace MvcApplication3
{
    public partial class SqlRepository : IRepositoryRole
    {
        [Inject]
        public LessonProjectDbDataContext Db { get; set; }

        
    }
}