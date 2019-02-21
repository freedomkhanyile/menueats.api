namespace menueats.api.DAL.Contracts.IRepositoryWrapper
{
    using menueats.api.DAL.Contracts.IDish;
    public interface IRepositoryWrapper
    {
        IDishRepository Dish { get; }
    }
}