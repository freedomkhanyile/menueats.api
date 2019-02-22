namespace menueats.api.DAL.Entities.Extensions.Dishes
{
    public static class DishExtensions
    {
        public static void Map(this Dish dbmodel, Dish model){

            dbmodel.Description = model.Description;
            dbmodel.DishLabel = model.DishLabel;
            dbmodel.DishName = model.DishName;
            dbmodel.Price = model.Price;
            dbmodel.ImageUrl = model.ImageUrl;
            dbmodel.Comments = model.Comments;
        }
    }   
}