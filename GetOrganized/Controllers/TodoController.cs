using GetOrganized.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace GetOrganized.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            ViewData["UserName"] = User.Identity.Name;
            return View(Todo.ThingsToBoDone);
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
        public ActionResult Create(Todo todo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Todo.ThingsToBoDone.Add(todo);
                    if (this.HttpContext.Session.Get<SessionSummary>("SessionSumary") == null)
                        HttpContext.Session.Set<SessionSummary>("SessionSumary", new SessionSummary());

                    var summary = HttpContext.Session.Get<SessionSummary>("SessionSumary");
                    summary.todos.Add(todo);
                    return RedirectToAction(nameof(Index));
                }
                    return View();
            }
            catch
            {
                return View();
            }
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