using BookApp.Models.DTO;
using BookApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookApp.Controllers
{
    public class OrderController : Controller
    {
        private LibraryRepository repo;

        public OrderController()
        {
            this.repo = new LibraryRepository();
        }
        // GET: Reader
        public ActionResult Index(PersonBookDto item = null)
        {
            var persons = repo.Persons.Get().Select(s => new SelectListItem { Text = s.FullName, Value = s.Id.ToString()}).ToList();
            var books = repo.Books.GetFree().Select(s => new SelectListItem { Text = s.Title, Value = s.Id.ToString() }).ToList();
            ViewBag.Data = GetOrderData();
            ViewBag.Orders = repo.Orders.Get().OrderByDescending(o => o.Id).Take(10).ToList();
            if (item == null)
                item = new PersonBookDto();
            return View(item);
        }
        [HttpPost]
        public ActionResult NewOrder(PersonBookDto order)
        {
            if (ModelState.IsValid)
            {
                repo.Orders.Create(order);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", order);
        }
        private OrderDto GetOrderData()
        {
            var persons = repo.Persons.Get().Select(s => new SelectListItem { Text = s.FullName, Value = s.Id.ToString() }).ToList();
            var books = repo.Books.GetFree().Select(s => new SelectListItem { Text = $"{s.Title}[{s.Author}]", Value = s.Id.ToString() }).ToList();
            return new OrderDto { Books = books, Persons = persons };
        }
    }
}