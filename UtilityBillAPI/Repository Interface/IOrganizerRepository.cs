namespace EventManagementAPI.Repository_Interface
{
    public interface IOrganizerRepository
    {
        Task<IEnumerable<Organizer>> GetAllAsync();
        Task<Organizer> GetByIdAsync(int id);
        Task AddAsync(Organizer organizer);
        Task UpdateAsync(Organizer organizer);
        Task DeleteAsync(int id);
    }
}
