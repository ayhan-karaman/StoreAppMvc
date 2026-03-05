
using Microsoft.AspNetCore.Identity;

namespace Entities.Models.IdentityUser
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            RegistrationDate = DateTime.UtcNow;
        }
        public DateTime RegistrationDate { get; set; }
        public string? RegistrationAddress { get; set; }

        public DateTime? LastLoginDate { get; set; }
        public string? LastLoginIp { get; set; }
    }
}
