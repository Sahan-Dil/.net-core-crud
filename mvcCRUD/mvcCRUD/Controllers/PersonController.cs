using Microsoft.AspNetCore.Mvc;
using mvcCRUD.Models.Domain;

namespace mvcCRUD.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx)
        {
            _ctx = ctx; //dependancy injection
        }
        public IActionResult Index()
        {
            ViewBag.hello1 = "ViewBag hello...";
            ViewData["hello"] = "ViewData hello...";
            TempData["hello"] = "tempData hello...";
            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Person Added...";
                return RedirectToAction("AddPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added person !!!";
                return View();
            }
        }
        public IActionResult DisplayPersons()
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }

        public IActionResult DeletePerson(int id)
        {
            var person = _ctx.Person.Find(id);
            try {
                if (person != null)
                {
                    _ctx.Remove(person);
                    _ctx.SaveChanges();
                }
            }
            catch(Exception ex) {
            }
            return RedirectToAction("DisplayPersons");

        }

        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Person.Find(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Person.Update(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Person Edited Succesfully...";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not updated person !!!";
                return View();
            }
        }
    }
}
