using EventManagementAPI.Models;
using EventManagementAPI.Services;
using EventManagementAPI.Services_Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypeController : ControllerBase
    {
        private readonly ITicketTypeService _service;

        public TicketTypeController(ITicketTypeService service)
        {
            _service = service;
        }

        // GET: api/TicketType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketType>>> GetTicketTypes()
        {
            var ticketTypes = await _service.GetAllTicketTypesAsync();
            return Ok(ticketTypes);
        }

        // GET: api/TicketType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketType>> GetTicketType(int id)
        {
            var ticketType = await _service.GetTicketTypeByIdAsync(id);
            if (ticketType == null)
            {
                return NotFound();
            }
            return Ok(ticketType);
        }

        [HttpGet("ticket-typesbyeventid")]
        public async Task<ActionResult<IEnumerable<TicketType>>> GetTicketTypesByEventId([FromQuery] int eventId)
        {
            var ticketTypes = await _service.GetTicketTypesByEventIdAsync(eventId);

            if (ticketTypes == null || !ticketTypes.Any())
            {
                return NotFound();
            }

            return Ok(ticketTypes);
        }

        // POST: api/TicketType
        [HttpPost]
        public async Task<ActionResult<TicketType>> PostTicketType(TicketType ticketType)
        {
            await _service.CreateTicketTypeAsync(ticketType);
            return CreatedAtAction(nameof(GetTicketType), new { id = ticketType.Id }, ticketType);
        }

        // PUT: api/TicketType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketType(int id, TicketType ticketType)
        {
            if (id != ticketType.Id)
            {
                return BadRequest();
            }

            await _service.UpdateTicketTypeAsync(ticketType);
            return NoContent();
        }

        // DELETE: api/TicketType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketType(int id)
        {
            await _service.DeleteTicketTypeAsync(id);
            return NoContent();
        }
    }
}
