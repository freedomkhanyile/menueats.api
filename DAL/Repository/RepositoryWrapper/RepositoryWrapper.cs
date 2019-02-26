namespace menueats.api.DAL.Repository.RepositoryWrapper
{
    using menueats.api.DAL.Contracts.IAccount;
    using menueats.api.DAL.Contracts.IComment;
    using menueats.api.DAL.Contracts.IDish;
    using menueats.api.DAL.Contracts.IRepositoryWrapper;
    using menueats.api.DAL.DbContext;
    using menueats.api.DAL.Entities;
    using menueats.api.DAL.Repository.Account;
    using menueats.api.DAL.Repository.Comments;
    using menueats.api.DAL.Repository.Dishes;
    using Microsoft.AspNetCore.Identity;

    public class RepositoryWrapper : IRepositoryWrapper
    {

        public RepositoryWrapper(){}
        public RepositoryWrapper(RepositoryContext repositoryContext,SignInManager<User> signInManager )
        {
            _repositoryContext = repositoryContext;
            _signInManager = signInManager;
        }



        private RepositoryContext _repositoryContext { get; set; }
        private SignInManager<User> _signInManager {get; set;}
        private IDishRepository _dish;
        private ICommentsRepository _comment;
        private IAccountRepository _account;

        public IDishRepository Dish
        {
            get
            {
                if (_dish == null)
                    _dish = new DishRepository(_repositoryContext);

                return _dish;
            }
        }

        public ICommentsRepository Comment
        {
            get {
                if(_comment == null)
                        _comment = new CommentsRepository(_repositoryContext);
            
                return _comment;               
            }
        }

        public IAccountRepository Account {
            get {
                if(_account == null)
                        _account = new AccountRepository(_repositoryContext, _signInManager);
                
                return _account;
            }
        }

    }
}