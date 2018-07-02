using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Persistence.Repositories
{
    public class BaseRepository<T>  where T : class
    {
        public readonly ISession session;

        protected BaseRepository(ISession session)
        {

            this.session = session;
        }

        public virtual void SaveOrUpdate(T model)
        {
            session.Save(model);
            session.Flush();
        }


        public virtual List<T> GetAll()
        {
            return (List<T>)session.CreateCriteria<T>().List<T>();
        }
    }
}
