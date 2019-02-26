using System;
using System.Collections.Generic;
using System.Linq;
using menueats.api.DAL.Contracts.IComment;
using menueats.api.DAL.DbContext;
using menueats.api.DAL.Entities;
using menueats.api.DAL.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace menueats.api.DAL.Repository.Comments
{
    public class CommentsRepository 
    : RepositoryBase<Comment>, ICommentsRepository
    {
        public CommentsRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
        {
        }

        
        public bool AddComment(Comment model)
        {
           var isDone = false;
           model.Date = DateTime.Now;
           try
           {
               Create(model);
               Save();
               isDone = true;
           }
           catch (System.Exception)
           {
               
               throw;
           }

           return isDone;
        }

        public IEnumerable<Comment> GetComments(int dishId)
        {
           return _repositoryContext.Comments
                    .Where(c => c.Dish.DishId == dishId)
                    .Include(c => c.User)
                    .ToList();
                            
        }
    }
}