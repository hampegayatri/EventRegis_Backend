using EventManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Services
{
    public interface IEventRegistrationService
    {
        Task<IEnumerable<EventRegistration>> GetAllRegistrationsAsync();
        Task<EventRegistration> GetRegistrationByIdAsync(int id);
        Task CreateRegistrationAsync(EventRegistration registration);
        Task UpdateRegistrationAsync(EventRegistration registration);
        Task<IEnumerable<EventRegistration>> GetRegistrationsByUserIdAsync(string userId);
        Task CancelRegistrationAsync(int id);
        Task DeleteRegistrationAsync(int id);
    }
}
