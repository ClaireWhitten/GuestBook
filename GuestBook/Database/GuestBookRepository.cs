using GuestBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBook.Database
{
    public class GuestBookRepository : IRepository
    {
        private readonly AppDbContext ctx;



        public GuestBookRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }


        public void AddComment(Comment comment)
        {
            ctx.Comments.Add(comment);
            ctx.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            Comment comment = ctx.Comments.FirstOrDefault(c => c.Id == id);

            if (comment != null)
            {
                ctx.Comments.Remove(comment);
                ctx.SaveChanges();
            }
        }

        public Comment GetComment(int id)
        {
            return ctx.Comments.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Comment> GetComments()
        {
            return ctx.Comments;
        }

        public void UpdateComment(Comment comment)
        {
            ctx.SaveChanges();
        }
    }
}
