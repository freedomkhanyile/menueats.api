using System.ComponentModel.DataAnnotations;

namespace menueats.api.DAL.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}