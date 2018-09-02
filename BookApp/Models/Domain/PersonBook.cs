using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookApp.Models.Domain
{
    public class PersonBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [Required]
        public DateTime GetDate { get; set; }

        [Required]
        public int GetDays { get; set; }
    }
}