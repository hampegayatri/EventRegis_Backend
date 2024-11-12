using EventManagementAPI.DTOs;

namespace EventManagementAPI.Services_Interfaces
{
    public interface IEventDetailService
    {
        Task<IEnumerable<EventDetailDto>> GetAllEventDetailsAsync();
        Task<EventDetailDto> GetEventDetailByIdAsync(int id);
        Task AddEventDetailAsync(EventDetailDto eventDetailDto);
        Task UpdateEventDetailAsync(EventDetailDto eventDetailDto);
        Task DeleteEventDetailAsync(int id);

        // New method to add event details with ticket types
        Task AddEventDetailWithTicketTypesAsync(EventDetailDto eventDetailDto, List<TicketTypeDto> ticketTypesDto);
        Task<IEnumerable<EventDetailDto>> GetEventsByCategoryAsync(int categoryId);
        Task<List<EventDetailDto>> GetEventDetailsByOrganizerId(int organizerId, CancellationToken cancellationToken);
    }
}

