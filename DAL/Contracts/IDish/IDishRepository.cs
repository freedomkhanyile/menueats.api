namespace menueats.api.DAL.Contracts.IDish
{
    using System.Collections.Generic;
    using menueats.api.DAL.Entities;
    public interface IDishRepository
    {
        IEnumerable<Dish> GetDishes();
        Dish GetDishWithComments(int id);
        Dish GetDish(int id);
        IEnumerable<Dish> GetDishesByCategory(string category);

        bool AddDish(Dish model);
        bool UpdateDish(Dish dbmodel, Dish model);
    }
}