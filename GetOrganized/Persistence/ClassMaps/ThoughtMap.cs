using FluentNHibernate.Mapping;
using GetOrganized.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Persistence.ClassMaps
{
    public sealed class ThoughtMap : ClassMap<Thought>
    {
        public ThoughtMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            //Map(x => x.ImageAttachment);
            //Map(x => x.IsASomeday);
            References(x => x.Topic);
        }
    }
}
