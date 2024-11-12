using EventManagementAPI.Data;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Repositories
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketType>> GetAllAsync()
        {
            return await _context.TicketTypes.ToListAsync();
        }

        public async Task<TicketType> GetByIdAsync(int id)
        {
            return await _context.TicketTypes.FindAsync(id);
        }

        public async Task AddAsync(TicketType ticketType)
        {
            _context.TicketTypes.Add(ticketType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketType ticketType)
        {
            _context.Entry(ticketType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TicketType>> GetTicketTypesByEventIdAsync(int eventId)
        {
            return await _context.TicketTypes
                .Where(tt => tt.EventId == eventId)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticketType = await _context.TicketTypes.FindAsync(id);
            if (ticketType != null)
            {
                _context.TicketTypes.Remove(ticketType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
