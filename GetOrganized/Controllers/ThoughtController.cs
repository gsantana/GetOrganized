using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetOrganized.Models;
using GetOrganized.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GetOrganized.Controllers
{
    public class ThoughtController : Controller
    {
        // GET: Thought
        public ActionResult Index()
        {
            return View(Thought.Thoughts);
        }

        // GET: Thought/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Thought/Create
        public ActionResult Create()
        {
            ViewData["Topics"] = Topic.topics.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }

        // POST: Thought/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Thought collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ViewResult Process()
        {
            return View(Thought.Thoughts.First());
        }

        // GET: Thought/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Thought/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Thought/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Thought/Delete/5
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