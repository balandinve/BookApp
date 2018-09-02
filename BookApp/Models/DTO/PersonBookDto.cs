using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookApp.Models.DTO
{
    public class PersonBookDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Читатель")]
        public int PersonId { get; set; }
        public string PersonFullName { get; set; }
        [Required]
        [Display(Name = "Книга")]
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        [Required]
        [Display(Name = "Дата выдачи")]
        public DateTime GetDate { get; set; }
        [Required]
        [Display(Name = "Количество дней")]
        [Range(1,365,ErrorMessage ="Количество дней должно быть между {1} и {2}")]
        public int GetDays { get; set; } = 1;
    }
}