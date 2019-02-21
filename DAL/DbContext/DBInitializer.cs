namespace menueats.api.DAL.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using menueats.api.DAL.Entities;
    using Microsoft.AspNetCore.Identity;

    public class DBInitializer
    {
        private RepositoryContext _repositoryContext;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public DBInitializer(UserManager<User> userManager,
                             RoleManager<IdentityRole> roleManager,
                             RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            var user = await _userManager.FindByEmailAsync("admin@menu-eats.co.za");

            if (user == null)
            {
                //Check if there is a role for admin or not then create admin role.
                if (!(await _roleManager.RoleExistsAsync("Admin")))
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));

                //Create User object details to seed.
                user = new User()
                {
                    UserName = "adminmenu",
                    FirstName = "admin",
                    LastName = "user",
                    Email = "admin@menu-eats.co.za"
                };

                var createUserResult = await _userManager.CreateAsync(user, "Ahm3dia@!");
                var addRoleResult = await _userManager.AddToRoleAsync(user, "Admin");
                var AddClaimResult = await _userManager.AddClaimAsync(user, new Claim("SuperUser", "True"));

                if (!createUserResult.Succeeded || !addRoleResult.Succeeded || !AddClaimResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user or role");
                }
            }

            if (!_repositoryContext.Dishes.Any())
            {
                _repositoryContext.AddRange(_sampleDishes);
                await _repositoryContext.SaveChangesAsync();
            }
        }
        List<Dish> _sampleDishes = new List<Dish>
            {
                new Dish()
                  {
                      DishName = "Vadonut",
                      DishLabel = "Hot",
                      Category = "appetizer",
                      Price = 2.5m,
                      Description = "A quintessential ConFusion experience, is it a vada or is it a donut?",
                      ImageUrl = "/images/vadonut.jpg",
                  },
                  new Dish()
                  {
                      DishName = "Mugodu",
                      DishLabel = "Warm",
                      Category = "meal",
                      Price = 10.0m,
                      Description = "An African dish brought to the world?",
                      ImageUrl = "/images/mugodu.jpg",
                  },
                  new Dish()
                  {
                      DishName = "Red Valvet",
                      DishLabel = "Cold",
                      Category = "desert",
                      Price = 5.0m,
                      Description = "A slice or two who are we to judge",
                      ImageUrl = "/images/valvet.jpg",
                  }

            };
    }
}