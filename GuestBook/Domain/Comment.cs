using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBook.Domain
{
    public enum Mood
    {
        Happy,
        Ok,
        Angry,
        Sad
    }



    public class Comment
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public  string Name{ get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }


        public string PhotoUrl { get; set; }

        public Mood Mood { get; set; }
    }
}
