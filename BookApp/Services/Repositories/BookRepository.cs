using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookApp.Models;
using BookApp.Models.Domain;
using BookApp.Models.DTO;
using BookApp.Models.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace BookApp.Services.Repositories
{
    public class BookRepository
    {
        private LibraryContext db;

        public BookRepository(LibraryContext db)
        {
            this.db = db;
        }

        public List<BookDto> Get()
        {
            return db.Books.ProjectTo<BookDto>().ToList();
        }

        public List<BookDto> Get(BookFilter filter)
        {
            
            return db.Books.Where(w => String.IsNullOrEmpty(filter.Title)? true: w.Title.ToLower().Contains(filter.Title.ToLower()))
                .ProjectTo<BookDto>().ToList();
        }

        public BookDto Get(int id)
        {
            return Mapper.Map<Book,BookDto>(db.Books.FirstOrDefault(w => w.Id == id));
        }

        public List<BookDto> GetFree()
        {
            return db.Books
                .Where(w => 
                    w.Persons.Count() == 0 || 
                    w.Persons.Where(a => SqlFunctions.DateAdd("DAY", a.GetDays, a.GetDate) > DateTime.Now).Count() == 0)
                .ProjectTo<BookDto>().ToList();
        }
        public void Create(BookDto book)
        {
            var newBook = Mapper.Map<BookDto, Book>(book);
            db.Books.Add(newBook);
        }
        public void Update(BookDto book)
        {
            var updatedBook = Mapper.Map<BookDto, Book>(book);
            updatedBook = db.Books.Attach(updatedBook);
            db.Entry(updatedBook).State = System.Data.Entity.EntityState.Modified;

        }
        public void Delete(int id)
        {
            var book = db.Books.FirstOrDefault(w => w.Id == id);
            if (book != null)
            {

                db.Books.Remove(book);
            }
        }
        public bool IsHanded(int id)
        {
            var book =  db.Books.FirstOrDefault(w => w.Id == id);
            if(book != null)
            {
                return book.Persons.Any(w => SqlFunctions.DateAdd("DAY", w.GetDays, w.GetDate) > DateTime.Now.Date);
            }
            return false;
        }
        
        
    }
}