using BookApp.Models.DTO;
using BookApp.Models.Filters;
using BookApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookApp.Controllers
{
    public class PersonController : Controller
    {
        private LibraryRepository repo;

        public PersonController()
        {
            this.repo = new LibraryRepository();
        }
        // GET: Person
        public ActionResult Index()
        {
            var persons = repo.Persons.Get();
            return View(persons);
        }
        public ActionResult Filter(PersonFilter filter)
        {
            var persons = repo.Persons.Get(filter);
            return PartialView(persons);
        }
        public ActionResult Edit(int id = 0)
        {
            PersonDto person = new PersonDto();
            if (id != 0)
            {
                person = repo.Persons.Get(id);
                if (person == null)
                    HttpNotFound();
            }
            return View(person);
        }
        [HttpPost]
        public ActionResult Edit(PersonDto person)
        {
            if (ModelState.IsValid)
            {
                if (person.Id == 0)
                {
                    repo.Persons.Create(person);
                }
                else
                {
                    repo.Persons.Update(person);
                }
                repo.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(person);
        }

        public void Delete(int id)
        {
            if (!repo.Persons.HasBooks(id))
            {
                repo.Persons.Delete(id);
                RedirectToAction("Index");
            }
            
        }
    }
}