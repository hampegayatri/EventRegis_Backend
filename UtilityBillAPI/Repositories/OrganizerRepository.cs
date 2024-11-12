using EventManagementAPI.Data;
using EventManagementAPI.Repository_Interface;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories
{
    public class OrganizerRepository : IOrganizerRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganizerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Organizer>> GetAllAsync()
        {
            return await _context.Organizers.ToListAsync();
        }
        public async Task<Organizer> GetByIdAsync(int id)
        {
            return await _context.Organizers.FindAsync(id);
        }

        public async Task AddAsync(Organizer organizer)
        {
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Organizer organizer)
        {
            _context.Entry(organizer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id);
            if (organizer != null)
            {
                _context.Organizers.Remove(organizer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
