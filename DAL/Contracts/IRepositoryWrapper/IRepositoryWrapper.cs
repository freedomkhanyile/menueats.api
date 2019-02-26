namespace menueats.api.DAL.Contracts.IRepositoryWrapper
{
    using menueats.api.DAL.Contracts.IAccount;
    using menueats.api.DAL.Contracts.IComment;
    using menueats.api.DAL.Contracts.IDish;
    public interface IRepositoryWrapper
    {
        IDishRepository Dish { get; }

        ICommentsRepository Comment { get ;}

        IAccountRepository Account {get;}
    }
}