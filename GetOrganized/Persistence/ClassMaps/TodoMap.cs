using FluentNHibernate.Mapping;
using GetOrganized.Models;
using GetOrganized.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Persistence.ClassMaps
{
    public class TodoMap : ClassMap<Todo>
    {
        public TodoMap()
        {
            Id(x => x.Title);
            Map(x => x.Completed);
            Map(x => x.Outcome);
            References(x => x.Topic).ForeignKey().Not.LazyLoad();
        }
    }
}
