using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventManagementAPI.Data;
using EventManagementAPI.DTOs;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventManagementAPI.Repositories
{
    public class EventDetailRepository : IEventDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public EventDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventDetail>> GetAllEventDetailsAsync()
        {
            return await _context.EventDetails
                .Include(e => e.Organizer)
                .Include(e => e.Category)
                .Include(e => e.Artist)
                .ToListAsync();
        }

        public async Task<List<EventDetailDto>> GetEventDetailsByOrganizerId(int organizerId)
        {
            return await _context.EventDetails
.Where(eventDetail => eventDetail.OrganizerId == organizerId)
.Select(eventDetail => new EventDetailDto
{
    Id = eventDetail.Id,
    Name = eventDetail.Name,
    Description = eventDetail.Description,
    Date = eventDetail.Date,
    VenueId = eventDetail.VenueId,
    CategoryId = eventDetail.CategoryId,
    ArtistId = eventDetail.ArtistId,
    OrganizerId = eventDetail.OrganizerId,
    Tags = eventDetail.Tags,
}).ToListAsync();

        }
        public async Task<EventDetail> GetEventDetailByIdAsync(int id)
        {
            return await _context.EventDetails
                .Include(e => e.Organizer)
                .Include(e => e.Category)
                .Include(e => e.Artist)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEventDetailAsync(EventDetail eventDetail)
        {
            await _context.EventDetails.AddAsync(eventDetail);
        }

        public async Task AddEventDetailWithTicketTypesAsync(EventDetail eventDetail, List<TicketType> ticketTypes)
        {
            // Add the event detail first to get the Event ID
            await _context.EventDetails.AddAsync(eventDetail);
            await _context.SaveChangesAsync(); // Save to generate the Event ID

            // Add ticket types, linking them with the new event ID
            foreach (var ticketType in ticketTypes)
            {
                ticketType.EventId = eventDetail.Id;
                //ticketType.AvailableQuantity = ticketType.MaxCapacity - await GetRegisteredCountForEvent(eventDetail.Id, ticketType.Id);
                await _context.TicketTypes.AddAsync(ticketType);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventDetailAsync(EventDetail eventDetail)
        {
            var existingEvent = await _context.EventDetails.FindAsync(eventDetail.Id);

            if (existingEvent == null)
            {
                throw new KeyNotFoundException("Event not found.");
            }

            existingEvent.Tags = eventDetail.Tags;
            _context.Entry(existingEvent).CurrentValues.SetValues(eventDetail);
        }

        public async Task DeleteEventDetailAsync(int id)
        {
            var eventDetail = await _context.EventDetails.FindAsync(id);
            if (eventDetail != null)
            {
                _context.EventDetails.Remove(eventDetail);
            }
        }

        public async Task<IEnumerable<EventDetail>> GetEventsByCategoryAsync(int categoryId)
        {
            return await _context.EventDetails
                .Where(e => e.CategoryId == categoryId)
                .ToListAsync();
        }

        //private async Task<int> GetRegisteredCountForEvent(int eventId, int ticketTypeId)
        //{
        //    // Simulate counting the registered users/tickets based on event and ticket type
        //    // This logic assumes you have a registration table in your database
        //    return await _context.Registrations
        //        .Where(r => r.EventId == eventId && r.TicketTypeId == ticketTypeId)
        //        .CountAsync();
        //}
    }
}
