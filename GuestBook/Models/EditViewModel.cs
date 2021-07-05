using GuestBook.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBook.Models
{
    public class EditViewModel
    {

        [Required]
        public string Title { get; set; }

        //public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        //public DateTime Date { get; set; }

        [Required]
        public Mood Mood { get; set; }

        //public string PhotoUrl { get; set; }


    }
}
