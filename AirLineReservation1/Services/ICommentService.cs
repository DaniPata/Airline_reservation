using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
    public interface ICommentService
    {


        //IEnumerable<Comment> GetAllComments();
        //void CreateComment(Comment comment);
        //Comment GetComment(int commentID);
        //public void DeleteComment(Comment comment);
        //public void UpdateComment(Comment comment);
        //public Task<List<Comment>> GetAllComments();

        public IEnumerable<Comment> GetAllComments();
        public Task<Comment> GetCommentById(int id);
        public Task<bool> UpdateComment(int id, Comment comment);
        public Task<bool> CreateComment(Comment comment);
        public Task<bool> DeleteComment(int id);
        public bool CommentExists(int id);
    }
}
