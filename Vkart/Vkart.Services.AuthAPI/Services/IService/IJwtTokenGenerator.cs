using Vkart.Services.AuthAPI.Models;

namespace Vkart.Services.AuthAPI.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}
