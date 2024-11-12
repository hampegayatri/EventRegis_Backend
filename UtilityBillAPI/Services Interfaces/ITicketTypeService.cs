using EventManagementAPI.Models;

namespace EventManagementAPI.Services_Interfaces
{
    public interface ITicketTypeService
    {
        Task<IEnumerable<TicketType>> GetAllTicketTypesAsync();
        Task<TicketType> GetTicketTypeByIdAsync(int id);
        Task CreateTicketTypeAsync(TicketType ticketType);
        Task UpdateTicketTypeAsync(TicketType ticketType);
        Task DeleteTicketTypeAsync(int id);
        Task<IEnumerable<TicketType>> GetTicketTypesByEventIdAsync(int eventId);
    }
}
