using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetOrganized.Models;
using GetOrganized.Models.Domain;
using NHibernate;

namespace GetOrganized.Persistence.Repositories
{
    public class TodoRepository : BaseRepository<Todo>
    {
        public TodoRepository(ISession session) : base(session)
        {
        }
    }
}
