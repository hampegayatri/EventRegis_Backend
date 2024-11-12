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
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerService _service;

        public OrganizerController(IOrganizerService service)
        {
            _service = service;
        }

        // GET: api/Organizer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizerDto>>> GetOrganizers()
        {
            var organizers = await _service.GetAllOrganizersAsync();
            return Ok(organizers);
        }

        // GET: api/Organizer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizerDto>> GetOrganizer(int id)
        {
            var organizer = await _service.GetOrganizerByIdAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }
            return Ok(organizer);
        }

        // POST: api/Organizer
        [HttpPost]
        public async Task<ActionResult> PostOrganizer(OrganizerDto organizerDto)
        {
            await _service.CreateOrganizerAsync(organizerDto);
            return CreatedAtAction(nameof(GetOrganizer), new { id = organizerDto.Id }, organizerDto);
        }

        // PUT: api/Organizer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizer(int id, OrganizerDto organizerDto)
        {
            if (id != organizerDto.Id)
            {
                return BadRequest();
            }

            await _service.UpdateOrganizerAsync(id, organizerDto);
            return NoContent();
        }

        // DELETE: api/Organizer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            await _service.DeleteOrganizerAsync(id);
            return NoContent();
        }
    }
}
