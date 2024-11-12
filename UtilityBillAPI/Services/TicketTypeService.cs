using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using EventManagementAPI.Services_Interfaces;

namespace EventManagementAPI.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository _repository;

        public TicketTypeService(ITicketTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TicketType>> GetAllTicketTypesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TicketType> GetTicketTypeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateTicketTypeAsync(TicketType ticketType)
        {
            await _repository.AddAsync(ticketType);
        }

        public async Task UpdateTicketTypeAsync(TicketType ticketType)
        {
            await _repository.UpdateAsync(ticketType);
        }

        public async Task DeleteTicketTypeAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TicketType>> GetTicketTypesByEventIdAsync(int eventId)
        {
            return await _repository.GetTicketTypesByEventIdAsync(eventId);
        }
    }
}
