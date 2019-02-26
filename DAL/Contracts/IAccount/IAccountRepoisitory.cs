using System.Threading.Tasks;
using menueats.api.DAL.Models;

namespace menueats.api.DAL.Contracts.IAccount
{
    public interface IAccountRepository
    {
         Task <bool>  Login(LoginModel model);
    }
}