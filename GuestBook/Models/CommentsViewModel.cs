using GuestBook.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBook.Models
{
    public class CommentsViewModel
    {
        //Properties for the list of comments
        public IEnumerable<Comment> Comments { get; set; }


        //Properties for creating a comment
        [Required]
        public string Title { get; set; }

        //public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        //public DateTime Date { get; set; }

        [Required]
        public Mood? Mood { get; set; }

       


        //public string PhotoUrl { get; set; }
    }
}
