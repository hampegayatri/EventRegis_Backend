using EventManagementAPI.Models;
using EventManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegistrationController : ControllerBase
    {
        private readonly IEventRegistrationService _service;

        public EventRegistrationController(IEventRegistrationService service)
        {
            _service = service;
        }

        // GET: api/EventRegistration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventRegistrationDto>>> GetEventRegistrations()
        {
            var registrations = await _service.GetAllRegistrationsAsync();
            var registrationDtos = registrations.Select(r => new EventRegistrationDto
            {
                Id = r.Id,
                UserId = r.UserId,
                EventId = r.EventId,
                TicketTypeId = r.TicketTypeId,
                RegistrationDate = r.RegistrationDate,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Email = r.Email,
                MobileNumber = r.MobileNumber,
                Age = r.Age,
                Gender = r.Gender
            });
            return Ok(registrationDtos);
        }

    // GET: api/EventRegistration/5
    [HttpGet("{id}")]
        public async Task<ActionResult<EventRegistrationDto>> GetEventRegistration(int id)
        {
            var registration = await _service.GetRegistrationByIdAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            var registrationDto = new EventRegistrationDto
            {
                Id = registration.Id,
                UserId = registration.UserId,
                EventId = registration.EventId,
                TicketTypeId = registration.TicketTypeId,
                RegistrationDate = registration.RegistrationDate,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Email = registration.Email,
                MobileNumber = registration.MobileNumber,
                Age = registration.Age,
                Gender = registration.Gender
            };

            return Ok(registrationDto);
        }

        // POST: api/EventRegistration
        [HttpPost]
        public async Task<ActionResult<EventRegistrationDto>> PostEventRegistration([FromBody] EventRegistrationDto registrationDto)
        {
            var registration = new EventRegistration
            {
                UserId = registrationDto.UserId,
                EventId = registrationDto.EventId,
                TicketTypeId = registrationDto.TicketTypeId,
                RegistrationDate = registrationDto.RegistrationDate,
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
                MobileNumber = registrationDto.MobileNumber,
                Age = registrationDto.Age,
                Gender = registrationDto.Gender,
                Status = registrationDto.Status ?? "Approved"
            };

            await _service.CreateRegistrationAsync(registration);

            registrationDto.Id = registration.Id; // Assign the ID after creation
            return CreatedAtAction(nameof(GetEventRegistration), new { id = registration.Id }, registrationDto);
        }

        // PUT: api/EventRegistration/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventRegistration(int id, [FromBody] EventRegistrationDto registrationDto)
        {
            if (id != registrationDto.Id)
            {
                return BadRequest();
            }

            var registration = new EventRegistration
            {
                Id = registrationDto.Id,
                UserId = registrationDto.UserId,
                EventId = registrationDto.EventId,
                TicketTypeId = registrationDto.TicketTypeId,
                RegistrationDate = registrationDto.RegistrationDate,
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
                MobileNumber = registrationDto.MobileNumber,
                Age = registrationDto.Age,
                Gender = registrationDto.Gender,
                Status = registrationDto.Status ?? "Approved"
            };

            await _service.UpdateRegistrationAsync(registration);
            return NoContent();
        }
        //// GET: api/EventRegistration/latest-registration-id
        //[HttpGet("latest-registration-id")]
        //public async Task<ActionResult<string>> GetLatestRegistrationId()
        //{
        //    var registrationId = await _service.GetLastEventRegistrationIdAsync();
        //    if (string.IsNullOrEmpty(registrationId))
        //    {
        //        return NotFound(new { message = "No registrations found" });
        //    }

        //    return Ok(new { eventRegistrationId = registrationId });
        //}


        // DELETE: api/EventRegistration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventRegistration(int id)
        {
            await _service.DeleteRegistrationAsync(id);
            return NoContent();
        }
        // POST: api/EventRegistration/cancel/5
        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> CancelEventRegistration(int id)
        {
            await _service.CancelRegistrationAsync(id);
            return NoContent();
        }
        // GET: api/EventRegistration/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<EventRegistrationDto>>> GetEventRegistrationsByUserId(string userId)
        {
            // Validate the userId
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new { message = "User ID is required." });
            }

            // Fetch registrations for the given userId
            var registrations = await _service.GetRegistrationsByUserIdAsync(userId);

            // Check if registrations are found
            if (registrations == null || !registrations.Any())
            {
                return NotFound(new { message = "No registrations found for the given user ID." });
            }

            // Map the registrations to DTOs
            var registrationDtos = registrations.Select(r => new EventRegistrationDto
            {
                Id = r.Id,
                UserId = r.UserId,
                EventId = r.EventId,
                TicketTypeId = r.TicketTypeId,
                RegistrationDate = r.RegistrationDate,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Email = r.Email,
                MobileNumber = r.MobileNumber,
                Age = r.Age,
                Gender = r.Gender
            });

            // Return OK with the list of registration DTOs
            return Ok(registrationDtos);
        }

    }
}
