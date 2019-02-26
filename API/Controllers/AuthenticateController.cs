using menueats.api.DAL.Contracts.IRepositoryWrapper;
using menueats.api.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace menueats.api.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        public AuthenticateController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        private IRepositoryWrapper _repositoryWrapper;

        // [Route("[action]")]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginModel model)
        {

            try
            {
                var result = _repositoryWrapper.Account.Login(model);
                if (result.Result)
                    return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
            return BadRequest("Failed to login");
        }

    }
}