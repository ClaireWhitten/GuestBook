using GuestBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBook.Database
{
    public interface IRepository
    {
        IEnumerable<Comment> GetComments();

        Comment GetComment(int id);

        void DeleteComment(int id);

        void AddComment(Comment comment);

        void UpdateComment(Comment comment);
    }
}
