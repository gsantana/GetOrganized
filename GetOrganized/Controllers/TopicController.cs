using GetOrganized.Models;
using Handy.DotNETCoreCompatibility.ColourTranslations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;

namespace GetOrganized.Controllers
{
    public class TopicController : Controller
    {
        [TempData]
        public string Message { get; set; }

        // GET: Topic
        public ActionResult Index()
        {
            return View(Topic.topics);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var converter = new ColorConverter();
            var topic = new Topic();
            topic.Id = int.Parse(collection["Id"]);
            topic.Name = collection["Name"];

            Topic.topics.Add(topic);
            Message = "Your topic has been added.";

            return RedirectToAction(nameof(Index));
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Topic/Edit/5
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

        // GET: Topic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topic/Delete/5
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