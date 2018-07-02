using AutoProperties;
using GetOrganized.Models.Vadation;
using NHibernate.Validator.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GetOrganized.Models.Domain
{
    public class Todo : BaseModel, IValidatable
    {
        public static List<Todo> ThingsToBoDone = new List<Todo>() {
            new Todo() { Title = "Get Milk", Completed = false},
            new Todo() { Title = "Bringg Home Bacon", Completed = true}
        };

        public virtual int Id { get; set; }

        [Required]
        public virtual bool Completed { get; set; }
        [Required]
        [Length(0, 25)]
        public virtual string Title { get; set; }
        [Required]
        public virtual Topic Topic { get; set; }
        [Required]
        public virtual string Outcome { get; set; }

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
