using AirLineReservation1.Models;
using AirLineReservation1.Repository;
using AirLineReservation1.RepositoryWrapperr;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace AirLineReservation1.Services
{
    public class CommentService : ICommentService
    {


        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<bool> CreateComment(Comment comment)
        {
            try
            {
                _commentRepository.Create(comment);
                await _commentRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteComment(int id)
        {
            try
            {
                var comment = await GetCommentById(id);
                _commentRepository.Delete(comment);
                await _commentRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<Comment> GetAllComments()
        {
            IEnumerable<Comment> comments = _commentRepository.FindAll();

            return comments;
        }

        public Task<Comment> GetCommentById(int id)
        {
            try
            {
                return _commentRepository.FindByCondition(comment => comment.CommentId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateComment(int id, Comment comment)
        {
            try
            {
                await GetCommentById(id);
                _commentRepository.Update(comment);
                await _commentRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool CommentExists(int id)
        {
            return _commentRepository.FindByCondition(e => e.CommentId == id).Any();
        }
    }
}

