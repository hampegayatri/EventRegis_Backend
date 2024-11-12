using EventManagementAPI.Data;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using EventManagementAPI.Repository_Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Services
{
    public class EventRegistrationService : IEventRegistrationService
    {
        private readonly IEventRegistrationRepository _repository;


        public EventRegistrationService(IEventRegistrationRepository repository)
        {
            _repository = repository;

        }

        public async Task<IEnumerable<EventRegistration>> GetAllRegistrationsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<EventRegistration> GetRegistrationByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateRegistrationAsync(EventRegistration registration)
        {
            await _repository.AddAsync(registration);
        }

        public async Task UpdateRegistrationAsync(EventRegistration registration)
        {
            await _repository.UpdateAsync(registration);
        }
        //public async Task<string> GetLastEventRegistrationIdAsync()
        //{
        //    var lastRegistration = await _repository.GetLastRegistrationAsync();
        //    return lastRegistration?.Id.ToString(); ; // Adjust based on your model
        //}
        public async Task DeleteRegistrationAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task CancelRegistrationAsync(int id)
        {
            await _repository.UpdateStatusAsync(id, "Cancelled");

        }
        public async Task<IEnumerable<EventRegistration>> GetRegistrationsByUserIdAsync(string userId)
        {
            return await _repository.GetRegistrationsByUserIdAsync(userId);
        }
    }
}

