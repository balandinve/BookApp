using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookApp.Models;
using BookApp.Models.Domain;
using BookApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookApp.Services.Repositories
{
    public class OrderRepository
    {
        private LibraryContext db;

        public OrderRepository(LibraryContext db)
        {
            this.db = db;
        }
        public List<PersonBookDto> Get()
        {
            return db.PersonBooks.ProjectTo<PersonBookDto>().ToList();
        }
        public void Create(PersonBookDto order)
        {
            var newOrder = Mapper.Map<PersonBookDto, PersonBook>(order);
            db.PersonBooks.Add(newOrder);
        }
    }
}