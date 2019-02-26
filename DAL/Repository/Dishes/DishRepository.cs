using System;
using System.Collections.Generic;
using System.Linq;
using menueats.api.DAL.Contracts.IDish;
using menueats.api.DAL.DbContext;
using menueats.api.DAL.Entities;
using menueats.api.DAL.Entities.Extensions.Dishes;
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

        public bool AddDish(Dish model)
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
                    .Where(d => d.DishId == id)
                    .Include(d => d.Comments)
                    .FirstOrDefault();
        }

        public bool UpdateDish(Dish dbmodel, Dish model)
        {
            var isDone = false;
            try
            {
                dbmodel.Map(model);
                Update(dbmodel);
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