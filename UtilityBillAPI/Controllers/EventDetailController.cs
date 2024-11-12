using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementAPI.DTOs;
using EventManagementAPI.Services_Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventManagementAPI.Data;
using EventManagementAPI.Models;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailController : ControllerBase
    {
        private readonly IEventDetailService _eventDetailService;
        private readonly ApplicationDbContext _context;

        public EventDetailController(IEventDetailService eventDetailService, ApplicationDbContext context)
        {
            _eventDetailService = eventDetailService;
            _context = context;
        }

        // GET: api/EventDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDetailDto>>> GetEventDetails()
        {
            var eventDetails = await _eventDetailService.GetAllEventDetailsAsync();
            return Ok(eventDetails);
        }

        // GET: api/EventDetail/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailDto>> GetEventDetail(int id)
        {
            var eventDetail = await _eventDetailService.GetEventDetailByIdAsync(id);
            if (eventDetail == null)
            {
                return NotFound();
            }
            return Ok(eventDetail);
        }

        // POST: api/EventDetail
        [HttpPost]
        public async Task<ActionResult> CreateEventDetail(EventDetailDto eventDetailDto)
        {
            await _eventDetailService.AddEventDetailAsync(eventDetailDto);
            await _context.SaveChangesAsync(); // Save changes here
            return CreatedAtAction(nameof(GetEventDetail), new { id = eventDetailDto.Id }, eventDetailDto);
        }

        //// POST: api/EventDetail/CreateWithTickets
        //[HttpPost("CreateWithTickets")]
        //public async Task<ActionResult> CreateEventWithTickets([FromBody] CreateEventWithTicketsDto createEventWithTicketsDto)
        //{
        //    if (createEventWithTicketsDto == null || createEventWithTicketsDto.EventDetail == null || createEventWithTicketsDto.TicketTypes == null)
        //    {
        //        return BadRequest("Event details and ticket types are required.");
        //    }

        //    // Map DTO to EventDetail entity
        //    var eventDetail = new EventDetail
        //    {
        //        Name = createEventWithTicketsDto.EventDetail.Name,
        //        Description = createEventWithTicketsDto.EventDetail.Description,
        //        Date = createEventWithTicketsDto.EventDetail.Date,
        //        VenueId = createEventWithTicketsDto.EventDetail.VenueId,
        //        CategoryId = createEventWithTicketsDto.EventDetail.CategoryId,
        //        ArtistId = createEventWithTicketsDto.EventDetail.ArtistId,
        //        OrganizerId = createEventWithTicketsDto.EventDetail.OrganizerId,
        //        Tags = createEventWithTicketsDto.EventDetail.Tags
        //    };

        //    // Add EventDetail first
        //    await _context.EventDetails.AddAsync(eventDetail);
        //    await _context.SaveChangesAsync(); // Save to generate EventId

        //    // Create associated ticket types
        //    var ticketTypes = new List<TicketType>();
        //    foreach (var ticketTypeDto in createEventWithTicketsDto.TicketTypes)
        //    {
        //        var ticketType = new TicketType
        //        {
        //            EventId = eventDetail.Id, // Set the EventId
        //            Name = ticketTypeDto.Name,
        //            Price = ticketTypeDto.Price,
        //            MaxCapacity = ticketTypeDto.MaxCapacity,
        //            AvailableQuantity = ticketTypeDto.AvailableQuantity // Calculate available quantity
        //        };

        //        ticketTypes.Add(ticketType);
        //    }

        //    // Add ticket types to the database
        //    await _context.TicketTypes.AddRangeAsync(ticketTypes);
        //    await _context.SaveChangesAsync();

        //    // Return response
        //    return CreatedAtAction(nameof(GetEventDetail), new { id = eventDetail.Id }, eventDetail);
        //}    
        // PUT: api/EventDetail/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventDetail(int id, EventDetailDto eventDetailDto)
        {
            if (id != eventDetailDto.Id)
            {
                return BadRequest();
            }

            await _eventDetailService.UpdateEventDetailAsync(eventDetailDto);
            await _context.SaveChangesAsync(); // Save changes here
            return NoContent();
        }

        // DELETE: api/EventDetail/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventDetail(int id)
        {
            await _eventDetailService.DeleteEventDetailAsync(id);
            await _context.SaveChangesAsync(); // Save changes here
            return NoContent();
        }

        // GET: api/EventDetail/category/5
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetEventsByCategory(int categoryId)
        {
            var events = await _eventDetailService.GetEventsByCategoryAsync(categoryId);
            if (events == null || !events.Any())
            {
                return NotFound();
            }

            return Ok(events);
        }
        [HttpGet("GetEventDetailsByOrganizerId")]
        public async Task<ActionResult<List<EventDetailDto>>> GetEventDetailsByOrganizerId(int organizerId, CancellationToken cancellationToken)
        {
            if (organizerId <= 0)
                return BadRequest("Organizer ID must be greater than 0.");

            var result = await _eventDetailService.GetEventDetailsByOrganizerId(organizerId, cancellationToken);
            return Ok(result);
        }
    }
}

