using System.Threading.Tasks;
using menueats.api.DAL.Contracts.IAccount;
using menueats.api.DAL.DbContext;
using menueats.api.DAL.Entities;
using menueats.api.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace menueats.api.DAL.Repository.Account
{
    public class AccountRepository : IAccountRepository
    {
         
        public AccountRepository(RepositoryContext context, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }
        private RepositoryContext _context;
        private SignInManager<User> _signInManager;
        public async Task <bool> Login(LoginModel model)
        {
            var isDone = false;
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
             
             if(result.Succeeded)
                isDone = true;

            return isDone;
        }
    }
}