using AutoMapper;
using EventManagementAPI.DTOs;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services
{
    public class EventDetailService : IEventDetailService
    {
        private readonly IEventDetailRepository _eventDetailRepository;
        private readonly IMapper _mapper;

        public EventDetailService(IEventDetailRepository eventDetailRepository, IMapper mapper)
        {
            _eventDetailRepository = eventDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDetailDto>> GetAllEventDetailsAsync()
        {
            var eventDetails = await _eventDetailRepository.GetAllEventDetailsAsync();
            return _mapper.Map<IEnumerable<EventDetailDto>>(eventDetails);
        }

        public async Task<EventDetailDto> GetEventDetailByIdAsync(int id)
        {
            var eventDetail = await _eventDetailRepository.GetEventDetailByIdAsync(id);
            return _mapper.Map<EventDetailDto>(eventDetail);
        }

        public async Task AddEventDetailAsync(EventDetailDto eventDetailDto)
        {
            var eventDetail = _mapper.Map<EventDetail>(eventDetailDto);
            await _eventDetailRepository.AddEventDetailAsync(eventDetail);
        }

        public async Task AddEventDetailWithTicketTypesAsync(EventDetailDto eventDetailDto, List<TicketTypeDto> ticketTypesDto)
        {
            var eventDetail = _mapper.Map<EventDetail>(eventDetailDto);
            var ticketTypes = _mapper.Map<List<TicketType>>(ticketTypesDto);

            await _eventDetailRepository.AddEventDetailWithTicketTypesAsync(eventDetail, ticketTypes);
        }

        public async Task UpdateEventDetailAsync(EventDetailDto eventDetailDto)
        {
            var eventDetail = _mapper.Map<EventDetail>(eventDetailDto);
            await _eventDetailRepository.UpdateEventDetailAsync(eventDetail);
        }

        public async Task DeleteEventDetailAsync(int id)
        {
            await _eventDetailRepository.DeleteEventDetailAsync(id);
        }
        public async Task<IEnumerable<EventDetailDto>> GetEventsByCategoryAsync(int categoryId)
        {
            var events = await _eventDetailRepository.GetEventsByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<EventDetailDto>>(events);
        }
        public async Task<List<EventDetailDto>> GetEventDetailsByOrganizerId(int organizerId, CancellationToken cancellationToken)
        {
            if (organizerId <= 0)
                throw new ArgumentException("Organizer ID must be greater than 0.", nameof(organizerId));

            try
            {
                var events= await _eventDetailRepository.GetEventDetailsByOrganizerId(organizerId);
                return (events);
                
            }
            catch (Exception ex)
            {
                // Log the exception (log implementation not shown here)
                throw new ApplicationException("An error occurred while retrieving event details.", ex);
            }
        }
    }
}

