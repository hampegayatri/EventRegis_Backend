using EventManagementAPI.Models;

namespace EventManagementAPI.Data.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(ApplicationUser user);
    }
}
