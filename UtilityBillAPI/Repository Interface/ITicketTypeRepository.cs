using EventManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Repositories
{
    public interface ITicketTypeRepository
    {
        Task<IEnumerable<TicketType>> GetAllAsync();
        Task<TicketType> GetByIdAsync(int id);
        Task AddAsync(TicketType ticketType);
        Task UpdateAsync(TicketType ticketType);
        Task DeleteAsync(int id);
        Task<IEnumerable<TicketType>> GetTicketTypesByEventIdAsync(int eventId);
    }
}
