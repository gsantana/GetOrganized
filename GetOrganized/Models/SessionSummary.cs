using GetOrganized.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Models
{
    public class SessionSummary
    {
        public SessionSummary()
        {
            this.todos = new List<Todo>();
        }

        public List<Todo> todos { get; private set; }

        public override bool Equals(object obj)
        {
            var summary = obj as SessionSummary;
            if (summary == null)
                return false;

            if (summary == this)
                return true;

            for (int i = 0; i < todos.Count; i++)
            {
                if (!todos[i].Equals(summary.todos[i]))
                    return false;
            }


            return true;
        }

        public override int GetHashCode()
        {
            return -379148646 + EqualityComparer<List<Todo>>.Default.GetHashCode(todos);
        }
    }
}
