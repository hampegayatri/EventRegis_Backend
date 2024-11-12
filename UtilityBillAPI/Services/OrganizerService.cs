using EventManagementAPI.Repository_Interface;
using EventManagementAPI.Services_Interfaces;

namespace EventManagementAPI.Services
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _repository;

        public OrganizerService(IOrganizerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrganizerDto>> GetAllOrganizersAsync()
        {
            var organizers = await _repository.GetAllAsync();
            // Convert to DTOs
            return organizers.Select(o => new OrganizerDto
            {
                Id = o.Id,
                Name = o.Name,
                Email = o.Email,
                ContactNumber = o.ContactNumber
            });
        }

        public async Task<OrganizerDto> GetOrganizerByIdAsync(int id)
        {
            var organizer = await _repository.GetByIdAsync(id);
            if (organizer == null) return null;

            return new OrganizerDto
            {
                Id = organizer.Id,
                Name = organizer.Name,
                Email = organizer.Email,
                ContactNumber = organizer.ContactNumber
            };
        }

        public async Task CreateOrganizerAsync(OrganizerDto organizerDto)
        {
            var organizer = new Organizer
            {
                Name = organizerDto.Name,
                Email = organizerDto.Email,
                ContactNumber = organizerDto.ContactNumber
            };
            await _repository.AddAsync(organizer);
        }

        public async Task UpdateOrganizerAsync(int id, OrganizerDto organizerDto)
        {
            var organizer = await _repository.GetByIdAsync(id);
            if (organizer == null) return;

            organizer.Name = organizerDto.Name;
            organizer.Email = organizerDto.Email;
            organizer.ContactNumber = organizerDto.ContactNumber;

            await _repository.UpdateAsync(organizer);
        }

        public async Task DeleteOrganizerAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
