using EventManagementAPI.Models;

namespace EventManagementAPI.Repository_Interface
{
    public interface IEventRegistrationRepository
    {
        Task<IEnumerable<EventRegistration>> GetAllAsync();
        Task<EventRegistration> GetByIdAsync(int id);
        Task AddAsync(EventRegistration registration);
        Task UpdateAsync(EventRegistration registration);
        Task UpdateStatusAsync(int id, string status);
        Task<IEnumerable<EventRegistration>> GetRegistrationsByUserIdAsync(string userId);
        Task DeleteAsync(int id);
        //Task<string> GetLastRegistrationAsync();

    }
}
