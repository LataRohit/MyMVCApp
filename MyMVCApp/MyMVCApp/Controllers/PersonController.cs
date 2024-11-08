using System.Collections.Generic;
using System.Web.Mvc;
using FormValidationGridApp.Models;

namespace FormValidationGridApp.Controllers
{
    public class PersonController : Controller
    {
        // In-memory list to store persons (in real applications, use a database)
        private static List<Person> personList = new List<Person>();

        // GET: Person
        public ActionResult Index()
        {
            return View(personList); // Pass the list to the grid view
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                personList.Add(person); // Add the person to the list
                return RedirectToAction("Index"); // Redirect to show grid view
            }
            return View(person); // Show form with validation errors if invalid
        }
    }
}
