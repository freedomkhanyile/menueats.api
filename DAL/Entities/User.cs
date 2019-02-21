using Microsoft.AspNetCore.Identity;

namespace menueats.api.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}