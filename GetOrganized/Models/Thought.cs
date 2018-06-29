using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Models
{
    public class Thought
    {
        public static List<Thought> Thoughts = new List<Thought>() {
            new Thought{ Id = 1, Topic = Topic.topics[0], Name = "Thought 1" },
            new Thought{ Id = 1, Topic = Topic.topics[1], Name = "Thought 2" }
        };

        public int Id { get; set; }
        public Topic Topic { get; set; }
        public string Name { get; set; }
    }
}
