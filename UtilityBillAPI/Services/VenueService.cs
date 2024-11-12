using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using EventManagementAPI.Repository_Interface;
using EventManagementAPI.Services_Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository _repository;

        public VenueService(IVenueRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Venue>> GetAllVenuesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Venue> GetVenueByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateVenueAsync(Venue venue)
        {
            await _repository.AddAsync(venue);
        }

        public async Task UpdateVenueAsync(Venue venue)
        {
            await _repository.UpdateAsync(venue);
        }

        public async Task DeleteVenueAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
