using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public bool Completed { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Topic Topic { get; set; }
        [Required]
        public string Outcome { get; set; }

        public override bool Equals(object obj)
        {
            var todo = obj as Todo;
            return todo != null &&
                   Completed == todo.Completed &&
                   Title == todo.Title &&
                   EqualityComparer<Topic>.Default.Equals(Topic, todo.Topic) &&
                   Outcome == todo.Outcome;
        }
    }
}
