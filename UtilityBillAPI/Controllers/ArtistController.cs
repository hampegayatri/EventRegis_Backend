using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManagementAPI.Models;
using EventManagementAPI.Services_Interfaces;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        // GET: api/artist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            return Ok(artists);
        }

        // GET: api/artist/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        // POST: api/artist
        [HttpPost]
        public async Task<ActionResult> CreateArtist([FromBody] Artist artist)
        {
            if (artist == null)
            {
                return BadRequest();
            }

            await _artistService.AddArtistAsync(artist);
            return CreatedAtAction(nameof(GetArtistById), new { id = artist.Id }, artist);
        }

        // PUT: api/artist/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArtist(int id, [FromBody] Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }

            var existingArtist = await _artistService.GetArtistByIdAsync(id);
            if (existingArtist == null)
            {
                return NotFound();
            }

            await _artistService.UpdateArtistAsync(artist);
            return NoContent();
        }

        // DELETE: api/artist/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            await _artistService.DeleteArtistAsync(id);
            return NoContent();
        }
    }
}
