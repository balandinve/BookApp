using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookApp.Models.Domain
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public ICollection<PersonBook> Books { get; set; }
    }
}