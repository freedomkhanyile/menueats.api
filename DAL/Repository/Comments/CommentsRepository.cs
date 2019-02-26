using menueats.api.DAL.Contracts.IComment;
using menueats.api.DAL.DbContext;
using menueats.api.DAL.Entities;
using menueats.api.DAL.Repository.RepositoryBase;

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
    }
}