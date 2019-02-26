using menueats.api.DAL.Entities;

namespace menueats.api.DAL.Contracts.IComment
{
    public interface ICommentsRepository
    {
         bool AddComment(Comment model);
    }
}