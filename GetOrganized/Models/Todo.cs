using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Models
{
    public class Todo
    {
        public static List<Todo> ThingsToBoDone = new List<Todo>() {
            new Todo() { Title = "Get Milk", Completed = false},
            new Todo() { Title = "Bringg Home Bacon", Completed = true}
        };

        public bool Completed { get; set; }
        public string Title { get; set; }
    }
}
