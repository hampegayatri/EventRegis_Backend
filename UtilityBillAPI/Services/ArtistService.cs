using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementAPI.Models;
using EventManagementAPI.Services_Interfaces;  // Ensure this namespace is correct
using EventManagementAPI.Repositories;         // Ensure this namespace is correct

namespace EventManagementAPI.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository; // Use the interface

        public ArtistService(IArtistRepository artistRepository) // Inject the interface
        {
            _artistRepository = artistRepository;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _artistRepository.GetAllArtistsAsync(); // Ensure method names match
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            return await _artistRepository.GetArtistByIdAsync(id);
        }

        public async Task AddArtistAsync(Artist artist)
        {
            await _artistRepository.AddArtistAsync(artist);
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            await _artistRepository.UpdateArtistAsync(artist);
        }

        public async Task DeleteArtistAsync(int id)
        {
            await _artistRepository.DeleteArtistAsync(id);
        }
    }
}
