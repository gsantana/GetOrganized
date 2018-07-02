using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Models.Domain
{
    public class Thought
    {
        public static List<Thought> Thoughts = new List<Thought>() {
            new Thought{ Id = 1, Topic = Topic.topics[0], Name = "Thought 1" },
            new Thought{ Id = 1, Topic = Topic.topics[1], Name = "Thought 2" }
        };

        public virtual int Id { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual string Name { get; set; }
    }
}
