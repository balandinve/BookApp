using BookApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookApp.Models
{
    public class LibraryContext:DbContext
    {
        public LibraryContext() : base("ARMLibrarian")
        {
            Database.SetInitializer<LibraryContext>(new LibraryInitializer());

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonBook> PersonBooks { get; set; }
        
    }
}