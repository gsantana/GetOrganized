using FluentNHibernate.Mapping;
using GetOrganized.Models;
using GetOrganized.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Persistence.ClassMaps
{
    public class TopicMap : ClassMap<Topic>
    {
        public TopicMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            //Map(x => x.Color);
        }
    }
}
