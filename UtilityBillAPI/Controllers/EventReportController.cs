using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Ensure this using directive is included
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using EventManagementAPI.Data;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("registrations-per-event-category")]
        public async Task<IActionResult> GetRegistrationsPerEventCategory()
        {
            var data = await _context.EventRegistrations
                .Where(r => r.Status != "cancelled") // Exclude cancelled registrations
                .Join(_context.EventDetails,
                    r => r.EventId,
                    e => e.Id,
                    (r, e) => new { e.Name, e.CategoryId })
                .Join(_context.Categories, // Join with Categories to get category names
                    e => e.CategoryId,
                    c => c.Id,
                    (e, c) => new { e.Name, CategoryName = c.Name, e.CategoryId })
                .GroupBy(e => new { e.Name, e.CategoryName, e.CategoryId })
                .Select(g => new
                {
                    EventName = g.Key.Name,
                    CategoryName = g.Key.CategoryName,
                    Count = g.Count()
                })
                .ToListAsync();

            var csv = ConvertToCsv(data);
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "registrations_per_event_category.csv");
        }

        [HttpGet("oversubscribed-events-category")]
        public async Task<IActionResult> GetOversubscribedEventsCategory()
        {
            var data = await _context.EventRegistrations
                .Join(_context.EventDetails,
                    r => r.EventId,
                    e => e.Id,
                    (r, e) => new { e.Name, e.CategoryId, r.TicketTypeId, r.EventId })
                .Join(_context.TicketTypes,
                    er => er.TicketTypeId,
                    t => t.Id,
                    (er, t) => new { er.Name, er.CategoryId, t.MaxCapacity, er.EventId })
                .GroupBy(e => new { e.EventId, e.Name, e.CategoryId, e.MaxCapacity })
                .Select(g => new
                {
                    EventId = g.Key.EventId,
                    EventName = g.Key.Name,
                    CategoryId = g.Key.CategoryId,
                    MaxCapacity = g.Key.MaxCapacity,
                    TotalRegistrations = g.Count() // Count the number of registrations
                })
                .Where(e => e.TotalRegistrations > e.MaxCapacity) // Check if total registrations exceed max capacity
                .GroupBy(e => e.CategoryId)
                .Select(g => new
                {
                    CategoryId = g.Key,
                    OversubscribedCount = g.Count() // Count how many categories have oversubscribed events
                })
                .ToListAsync();

            var csv = ConvertToCsv(data);
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "oversubscribed_events_category.csv");
        }

        [HttpGet("registrations-per-user")]
        public async Task<IActionResult> GetRegistrationsPerUser()
        {
            var data = await _context.EventRegistrations
                .Where(r => r.Status != "cancelled") // Exclude cancelled registrations
                .GroupBy(r => new { r.UserId, r.Status })
                .Select(g => new
                {
                    UserId = g.Key.UserId,
                    Status = g.Key.Status,
                    Count = g.Count()
                })
                .ToListAsync();

            var csv = ConvertToCsv(data);
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "registrations_per_user.csv");
        }

        [HttpGet("events-for-children")]
        public async Task<IActionResult> GetEventsForChildren()
        {
            var data = await _context.EventDetails
                .Join(_context.EventRegistrations,
                    e => e.Id,
                    r => r.EventId,
                    (e, r) => new { e, r })
                .Join(_context.Venues, // Join with Venues to get city information
                    er => er.e.VenueId, // Assuming EventDetails has a VenueId
                    v => v.Id,
                    (er, v) => new { er.e.Id, er.e.Name, er.r.Age, v.City })
                .Where(er => er.Age > 5) // Filter for children above 5 years
                .GroupBy(er => new { er.Id, er.Name, er.City }) // Group by event and city
                .Select(g => new
                {
                    EventId = g.Key.Id,
                    EventName = g.Key.Name,
                    City = g.Key.City
                })
                .ToListAsync();

            var csv = ConvertToCsv(data); // Convert the result to CSV
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "events_for_children.csv");
        }
        [HttpGet("event-user-age-report")]
        public async Task<IActionResult> GetEventUserAgeReport()
        {
            var data = await _context.EventDetails
                .Join(_context.EventRegistrations,
                    e => e.Id,
                    r => r.EventId,
                    (e, r) => new { e, r })
                .Where(er => er.r.Age >= 18 && er.r.Age <= 25) // Filter for age between 18 and 25
                .Where(er => er.r.Status != "cancelled") // Exclude cancelled registrations
                .GroupBy(er => new { er.e.Id, er.e.Name }) // Group by event
                .Select(g => new
                {
                    EventId = g.Key.Id,
                    EventName = g.Key.Name,
                    UserCount = g.Count() // Count users in the age range
                })
                .ToListAsync();

            var csv = ConvertToCsv(data); // Convert the result to CSV
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "event_user_age_report.csv");
        }
        [HttpGet("event-cancellation-report")]
        public async Task<IActionResult> GetEventCancellationReport()
        {
            var data = await _context.EventDetails
                .Join(_context.EventRegistrations,
                    e => e.Id,
                    r => r.EventId,
                    (e, r) => new { e, r })
                .Where(er => er.r.Status == "cancelled") // Filter for cancelled registrations
                .GroupBy(er => new { er.e.Id, er.e.Name }) // Group by event
                .Select(g => new
                {
                    EventId = g.Key.Id,
                    EventName = g.Key.Name,
                    CancellationCount = g.Count() // Count cancellations
                })
                .ToListAsync();

            var csv = ConvertToCsv(data); // Convert the result to CSV
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "event_cancellation_report.csv");
        }
        [HttpGet("events-by-organizer/{organizerId}")]
        public async Task<IActionResult> GetEventsByOrganizer(int organizerId)
        {
            var events = await GetEventDetailsByOrganizerId(organizerId);
            var csv = ConvertToCsv(events);
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", $"events_by_organizer_{organizerId}.csv");
        }

        private async Task<IEnumerable<dynamic>> GetEventDetailsByOrganizerId(int organizerId)
        {
            return await _context.EventDetails
                .Where(e => e.OrganizerId == organizerId) // Assuming EventDetails has an OrganizerId
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Date,
                    e.Description
                })
                .ToListAsync();
        }


        private string ConvertToCsv<T>(IEnumerable<T> data)
        {
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(data);
                return writer.ToString();
            }
        }
    }
}
