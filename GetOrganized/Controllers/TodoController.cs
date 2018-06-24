using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetOrganized.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetOrganized.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
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
                Todo.ThingsToBoDone.Add(todo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(string title)
        {
            return View(Todo.ThingsToBoDone.Find(x=> x.Title == title));
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
    }
}