using EventManagementAPI.Data;
using EventManagementAPI.Models;
using EventManagementAPI.Repository_Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Repositories
{
    public class EventRegistrationRepository : IEventRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventRegistration>> GetAllAsync()
        {
            return await _context.EventRegistrations
                .Include(e => e.User)
                .Include(e => e.Event)
                .Include(e => e.TicketType)
                .ToListAsync();
        }

        public async Task<EventRegistration> GetByIdAsync(int id)
        {
            return await _context.EventRegistrations
                .Include(e => e.User)
                .Include(e => e.Event)
                .Include(e => e.TicketType)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(EventRegistration registration)
        {
            _context.EventRegistrations.Add(registration);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EventRegistration registration)
        {
            _context.EventRegistrations.Update(registration);
            await _context.SaveChangesAsync();
        }

        public async Task<EventRegistration> GetLastRegistrationAsync()
        {
            return await _context.EventRegistrations
                .OrderByDescending(r => r.Id) // Adjust based on your primary key
                .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var registration = await _context.EventRegistrations.FindAsync(id);
            if (registration != null)
            {
                _context.EventRegistrations.Remove(registration);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<EventRegistration>> GetRegistrationsByUserIdAsync(string userId)
        {
            return await _context.EventRegistrations
                                 .Where(r => r.UserId == userId)
                                 .ToListAsync();
        }
        public async Task UpdateStatusAsync(int id, string status)
        {
            var registration = await _context.EventRegistrations.FindAsync(id);
            if (registration != null)
            {
                registration.Status = status;
                _context.EventRegistrations.Update(registration);
                await _context.SaveChangesAsync();
            }
        }
    }
}
