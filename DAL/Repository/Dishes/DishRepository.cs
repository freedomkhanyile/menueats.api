using System;
using System.Collections.Generic;
using System.Linq;
using menueats.api.DAL.Contracts.IDish;
using menueats.api.DAL.DbContext;
using menueats.api.DAL.Entities;
using menueats.api.DAL.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace menueats.api.DAL.Repository.Dishes
{
    public class DishRepository
        : RepositoryBase<Dish>, IDishRepository
    {
        public DishRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {

        }

        public Dish GetDish(int id)
        {
            return _repositoryContext.Dishes
                    .Where(d => d.DishId == id)
                    .FirstOrDefault();
        }

        public IEnumerable<Dish> GetDishes()
        {
            return _repositoryContext.Dishes.ToList();
        }

        public IEnumerable<Dish> GetDishesByCategory(string category)
        {
            return _repositoryContext.Dishes
                    .Where(c => c.Category.Equals(category,  StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(d => d.DishName)
                    .ToList();
        }   

        public Dish GetDishWithComments(int id)
        {
            return _repositoryContext.Dishes
                    .Include(d => d.Comments)
                    .Where(d => d.DishId == id)
                    .FirstOrDefault();
        }
    }
}