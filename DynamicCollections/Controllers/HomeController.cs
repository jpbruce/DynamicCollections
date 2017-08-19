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
            return View(new PersonsViewModel());
        }

        [HttpPost]
        public ActionResult Index(PersonsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // we have errors, return the view with messages
                return View(viewModel);
            }

            return Content("success");
        }

        [HttpGet]
        public ActionResult RenderPerson()
        {
            return View("_Person");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}