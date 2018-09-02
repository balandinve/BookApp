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
    public class PersonRepository
    {
        private LibraryContext db;

        public PersonRepository(LibraryContext db)
        {
            this.db = db;
        }
        
        public PersonDto Get(int id)
        {
            return Mapper.Map<Person,PersonDto>(db.Persons.FirstOrDefault(w => w.Id == id));
        }

        public List<PersonDto> Get()
        {
            return db.Persons.ProjectTo<PersonDto>().ToList();
        }

        public List<PersonDto> Get(PersonFilter filter)
        {
            return db.Persons.Where(w => String.IsNullOrEmpty(filter.FullName)? true: w.FullName.ToLower().Contains(filter.FullName.ToLower())).ProjectTo<PersonDto>().ToList();
        }
        public void Create(PersonDto person)
        {
            var newPerson = Mapper.Map<PersonDto, Person>(person);
            db.Persons.Add(newPerson);
        }
        public void Update(PersonDto person)
        {
            var updated = Mapper.Map<PersonDto, Person>(person);
            updated = db.Persons.Attach(updated);
            db.Entry(updated).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete (int id)
        {

        }

        public bool HasBooks(int id)
        {
            var person = db.Persons.FirstOrDefault(w => w.Id == id);
            if (person != null)
            {
                return person.Books.Any(w => SqlFunctions.DateAdd("DAY", w.GetDays, w.GetDate) > DateTime.Now.Date);
            }
            return false;
        }

    }
}