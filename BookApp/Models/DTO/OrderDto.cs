using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookApp.Models.DTO
{
    public class OrderDto
    {
        public List<SelectListItem> Persons { get; set; }
        public List<SelectListItem> Books { get; set; }
        public OrderDto()
        {
            this.Persons = new List<SelectListItem>();
            this.Books = new List<SelectListItem>();
        }
    }
}