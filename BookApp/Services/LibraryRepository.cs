using BookApp.Models;
using BookApp.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookApp.Services
{
    public class LibraryRepository:IDisposable
    {
        private LibraryContext db;
        private PersonRepository persons;
        private BookRepository books;
        private OrderRepository orders;

        public LibraryRepository()
        {
            db = new LibraryContext();
        }

        public PersonRepository Persons
        {
            get
            {
                if (persons == null)
                    persons = new PersonRepository(db);
                return persons;
            }
        }
        public BookRepository Books {
            get
            {
                if(books == null)
                    books = new BookRepository(db);
                return books;
            }
        }
        public OrderRepository Orders
        {
            get
            {
                if (orders == null)
                    orders = new OrderRepository(db);
                return orders;
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~LibraryRepository() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}