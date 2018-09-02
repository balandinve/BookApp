using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookApp.Models.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "День рождения")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public List<PersonBookDto> Books { get; set; }
        public PersonDto()
        {
            this.Books = new List<PersonBookDto>();
        }
    }
}