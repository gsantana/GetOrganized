using GetOrganized.Models.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Persistence.Repositories
{
    public class TopicRepository : BaseRepository<Topic>
    {
        public TopicRepository(ISession session) : base(session)
        {
        }
    }
}
