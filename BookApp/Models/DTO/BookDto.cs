using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookApp.Models.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Артикул")]
        public string Article { get; set; }
        [Required]
        [Display(Name = "Год")]
        [Range(1,2018,ErrorMessage ="Год должен быть между {1} и {2}")]
        public int Year { get; set; }

        public List<PersonBookDto> Persons { get; set; }
        public BookDto()
        {
            this.Persons = new List<PersonBookDto>();
        }
    }
}