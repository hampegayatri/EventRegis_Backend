using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementAPI.DTOs;
using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories.Interfaces
{
    public interface IEventDetailRepository
    {
        Task<IEnumerable<EventDetail>> GetAllEventDetailsAsync();
        Task<EventDetail> GetEventDetailByIdAsync(int id);
        Task AddEventDetailAsync(EventDetail eventDetail);
        Task UpdateEventDetailAsync(EventDetail eventDetail);
        Task DeleteEventDetailAsync(int id);

        // New method to add event details with ticket types
        Task AddEventDetailWithTicketTypesAsync(EventDetail eventDetail, List<TicketType> ticketTypes);
        Task<IEnumerable<EventDetail>> GetEventsByCategoryAsync(int categoryId);

        Task<List<EventDetailDto>> GetEventDetailsByOrganizerId(int organizerId);
    }
}
