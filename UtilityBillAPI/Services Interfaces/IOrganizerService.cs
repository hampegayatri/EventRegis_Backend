namespace EventManagementAPI.Services_Interfaces
{
    public interface IOrganizerService
    {
        Task<IEnumerable<OrganizerDto>> GetAllOrganizersAsync();
        Task<OrganizerDto> GetOrganizerByIdAsync(int id);
        Task CreateOrganizerAsync(OrganizerDto organizerDto);
        Task UpdateOrganizerAsync(int id, OrganizerDto organizerDto);
        Task DeleteOrganizerAsync(int id);
    }
}
