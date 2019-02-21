namespace menueats.api.DAL.Repository.RepositoryWrapper
{
    using menueats.api.DAL.Contracts.IDish;
    using menueats.api.DAL.Contracts.IRepositoryWrapper;
    using menueats.api.DAL.DbContext;
    using menueats.api.DAL.Repository.Dishes;
    public class RepositoryWrapper : IRepositoryWrapper
    {

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        private RepositoryContext _repositoryContext { get; set; }
        private IDishRepository _dish;

        public IDishRepository Dish
        {
            get
            {
                if (_dish == null)
                    _dish = new DishRepository(_repositoryContext);

                return _dish;
            }
        }

    }
}