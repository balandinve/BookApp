using BookApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookApp.Models
{
    public class LibraryInitializer: CreateDatabaseIfNotExists<LibraryContext>
    {
        protected override void Seed(LibraryContext db)
        {
            Book b1 = new Book { Title = "Анна Каренина", Author = "Л. Толстой", Article = "001", Year = 1873 };
            Book b2 = new Book { Title = "Мастер и Маргарита", Author = "М. Булгаков", Article = "002", Year = 1937 };
            Book b3 = new Book { Title = "Грозовой перевал", Author = "Э. Бронте", Article = "003", Year = 1846 };
            Book b4 = new Book { Title = "Евгений Онегин", Author = "А. Пушкин", Article = "004", Year = 1831 };
            Book b5 = new Book { Title = "Собор Парижской Богоматери", Author = "В. Гюго", Article = "005", Year = 1831 };
            Book b6 = new Book { Title = "Унесенные ветром", Author = "М. Митчелл", Article = "006", Year = 1935 };

            Person p1 = new Person { FullName = "Петров П.П.", Birthday = new DateTime(1990, 3, 3) };
            Person p2 = new Person { FullName = "Иванов И.И.", Birthday = new DateTime(1995, 8, 8) };
            Person p3 = new Person { FullName = "Николаев Н.Н.", Birthday = new DateTime(1980, 10, 10) };

            db.Books.AddRange(new List<Book>{ b1, b2, b3, b4, b5, b6 });
            db.Persons.AddRange(new List<Person> { p1, p2, p3 });

            db.SaveChanges();

        }
    }
}