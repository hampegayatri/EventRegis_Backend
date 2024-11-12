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
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _service;

        public VenueController(IVenueService service)
        {
            _service = service;
        }

        // GET: api/Venue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        {
            var venues = await _service.GetAllVenuesAsync();
            return Ok(venues);
        }

        // GET: api/Venue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venue>> GetVenue(int id)
        {
            var venue = await _service.GetVenueByIdAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            return Ok(venue);
        }

        // POST: api/Venue
        [HttpPost]
        public async Task<ActionResult<Venue>> PostVenue(Venue venue)
        {
            await _service.CreateVenueAsync(venue);
            return CreatedAtAction(nameof(GetVenue), new { id = venue.Id }, venue);
        }

        // PUT: api/Venue/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenue(int id, Venue venue)
        {
            if (id != venue.Id)
            {
                return BadRequest();
            }

            await _service.UpdateVenueAsync(venue);
            return NoContent();
        }

        // DELETE: api/Venue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            await _service.DeleteVenueAsync(id);
            return NoContent();
        }
    }
}
