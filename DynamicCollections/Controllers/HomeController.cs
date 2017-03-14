using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicCollections.Models;

namespace DynamicCollections.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PersonsCollection());
        }

        [HttpPost]
        public ActionResult Index(PersonsCollection personsCollection)
        {
            if (!ModelState.IsValid)
            {
                // we have errors, return the view with messages
                return View(personsCollection);
            }
            else
            {
                return Content("success");
            }

            //return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult RenderPerson()
        {
            return View("Person");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
