using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookApp.Models.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        [Required]
        public string Article { get; set; }
        [Required]
        public int Year { get; set; }
        public virtual ICollection<PersonBook> Persons { get; set; }
    }
}