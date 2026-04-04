using Microsoft.AspNetCore.Identity;

namespace Vkart.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public  string Name { get; set; }

    }
}
