using GetOrganized.Models;
using GetOrganized.Models.Domain;
using GetOrganized.Persistence;
using GetOrganized.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace GetOrganized.Controllers
{
    public class TodoController : Controller
    {
        public TodoRepository todoRepo;
        public TodoController(TodoRepository todoRepository)
        {
            todoRepo = todoRepository;
        }

        //public TodoController()
        //{
        //}

        //public TodoController(NHibernate.ISession todoRepository)
        //{
        //    var a = todoRepository;
        //}

        // GET: Todo
        public ActionResult Index()
        {
            ViewData["UserName"] = User.Identity.Name;
            return View(todoRepo.GetAll());
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(TransactionAttribute))]
        public ActionResult Create(Todo todo)
        {
            //try
            //{
            //if (ModelState.IsValid)
            //{
            Todo.ThingsToBoDone.Add(todo);
            if (this.HttpContext.Session.Get<SessionSummary>("SessionSumary") == null)
                HttpContext.Session.Set<SessionSummary>("SessionSumary", new SessionSummary());

            var a = todo.Title;

            var summary = HttpContext.Session.Get<SessionSummary>("SessionSumary");
            summary.todos.Add(todo);
            //var todoProxy = ModelProxy<Todo>.Create(todo);
            //var b = todoProxy.Title;
            //todoProxy.Title = "sfadfafd";
            todoRepo.SaveOrUpdate(todo);
            return RedirectToAction(nameof(Index));
            //}
            return View();
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(string title)
        {
            return View(Todo.ThingsToBoDone.Find(x => x.Title == title));
        }

        // POST: Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string oldTitle, Todo newTodo)
        {
            try
            {
                Todo.ThingsToBoDone.RemoveAll(x => x.Title == oldTitle);
                Todo.ThingsToBoDone.Add(newTodo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(string title)
        {
            Todo.ThingsToBoDone.RemoveAll(x => x.Title == title);
            return RedirectToAction(nameof(Index));
        }

        // POST: Todo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Convert(Thought thought, string outcome)
        {
            var todo = new Todo()
            {

                Completed = false,
                Outcome = outcome,
                Title = thought.Name,
                Topic = Topic.topics.Find(x => x.Id == thought.Topic.Id)
            };

            Todo.ThingsToBoDone.Add(todo);
            if (this.HttpContext.Session.Get<SessionSummary>("SessionSumary") == null)
                HttpContext.Session.Set<SessionSummary>("SessionSumary", new SessionSummary());

            var summary = HttpContext.Session.Get<SessionSummary>("SessionSumary");
            summary.todos.Add(todo);
            Thought.Thoughts.RemoveAll(x => x.Name == thought.Name);
            return RedirectToAction("Process", "Thought");
        }
    }
}