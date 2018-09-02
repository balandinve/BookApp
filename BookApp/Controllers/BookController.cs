using BookApp.Models.DTO;
using BookApp.Models.Filters;
using BookApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookApp.Controllers
{
    public class BookController : Controller
    {
        private LibraryRepository repo;

        public BookController()
        {
            this.repo = new LibraryRepository();
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = repo.Books.Get();
            return View(books);
        }
        [HttpPost]
        public ActionResult Filter(BookFilter filter)
        {
            var books = repo.Books.Get(filter);
            return PartialView(books);
        }
        public ActionResult Edit(int id = 0)
        {
            BookDto book = new BookDto();
            if(id != 0)
            {
                book = repo.Books.Get(id);
                if (book == null)
                    HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(BookDto book)
        {
            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    repo.Books.Create(book);
                }
                else
                {
                    repo.Books.Update(book);
                }
                repo.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(book);
        }

        public ActionResult Delete(int id)
        {
            if (!repo.Books.IsHanded(id))
            {
                repo.Books.Delete(id);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}