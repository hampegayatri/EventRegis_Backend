using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using EventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using EventManagementAPI.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            // Get the UserManager and RoleManager services
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Seed roles
            await SeedRolesAsync(roleManager);

            // Seed users
            await SeedUsersAsync(userManager, roleManager);
            // Seed categories
            await SeedCategoriesAsync(dbContext);

            // Seed ticket types
            await SeedTicketTypesAsync(dbContext);

            // Seed venues
            await SeedVenuesAsync(dbContext);

            // Seed artists
            await SeedArtistsAsync(dbContext);

            // Seed organizers
            await SeedOrganizersAsync(dbContext);
        }
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = new[] { "Admin", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Admin user
        if (await userManager.FindByEmailAsync("admin@example.com") == null)
        {
            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@example.com",
            };

            var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");
            if (result.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
                if (!roleResult.Succeeded)
                {
                    // Log or handle errors
                    Console.WriteLine("Failed to assign role: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                }
            }
            else
            {
                // Log or handle errors
                Console.WriteLine("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        // Regular user
        if (await userManager.FindByEmailAsync("user@example.com") == null)
        {
            var regularUser = new ApplicationUser
            {
                UserName = "user",
                Email = "user@example.com",
            };

            var result = await userManager.CreateAsync(regularUser, "UserPassword123!");
            if (result.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(regularUser, "User");
                if (!roleResult.Succeeded)
                {
                    // Log or handle errors
                    Console.WriteLine("Failed to assign role: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                }
            }
            else
            {
                // Log or handle errors
                Console.WriteLine("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }


        }

    }
    private static async Task SeedCategoriesAsync(ApplicationDbContext dbContext)
    {
        if (!dbContext.Categories.Any())
        {
            dbContext.Categories.AddRange(
                new Category { Name = "Music", Description = "Music-related events" },
                new Category { Name = "Art", Description = "Art exhibitions and shows" },
                new Category { Name = "Sports", Description = "Sports events and matches" }
            );
            await dbContext.SaveChangesAsync();
        }
    }

    private static async Task SeedTicketTypesAsync(ApplicationDbContext dbContext)
    {
        if (!dbContext.TicketTypes.Any())
        {
            dbContext.TicketTypes.AddRange(
                new TicketType { Name = "General Admission", Price = 50.00m, AvailableQuantity = 100 },
                new TicketType { Name = "Premium", Price = 150.00m, AvailableQuantity = 20 },
                new TicketType { Name = "Economic", Price = 80.00m, AvailableQuantity = 50 }
            );
            await dbContext.SaveChangesAsync();
        }
    }

    private static async Task SeedVenuesAsync(ApplicationDbContext dbContext)
    {
        if (!dbContext.Venues.Any())
        {
            dbContext.Venues.AddRange(
                new Venue { Name = "Grand Hall", Address = "123 Main St", Capacity = 500 },
                new Venue { Name = "Open Arena", Address = "456 Elm St", Capacity = 1000 },
                new Venue { Name = "Intimate Studio", Address = "789 Oak St", Capacity = 150 }
            );
            await dbContext.SaveChangesAsync();
        }
    }

    private static async Task SeedArtistsAsync(ApplicationDbContext dbContext)
    {
        if (!dbContext.Artists.Any())
        {
            dbContext.Artists.AddRange(
                new Artist { Name = "John Doe", Genre = "Rock", Bio = "Rock singer and songwriter.", ContactInfo = "john.doe@example.com" },
                new Artist { Name = "Jane Smith", Genre = "Jazz", Bio = "Jazz musician and composer.", ContactInfo = "jane.smith@example.com" },
                new Artist { Name = "The Band", Genre = "Pop", Bio = "Popular band with various hits.", ContactInfo = "band@example.com" },
                new Artist { Name = "Alice Johnson", Genre = "Classical", Bio = "Classical pianist and composer.", ContactInfo = "alice.johnson@example.com" },
                new Artist { Name = "Bob Brown", Genre = "Hip Hop", Bio = "Hip hop artist and rapper.", ContactInfo = "bob.brown@example.com" },
                new Artist { Name = "Catherine Lee", Genre = "Country", Bio = "Country music singer and songwriter.", ContactInfo = "catherine.lee@example.com" },
                new Artist { Name = "David Williams", Genre = "Blues", Bio = "Blues guitarist and vocalist.", ContactInfo = "david.williams@example.com" }
            );
            await dbContext.SaveChangesAsync();
        }
    }

    private static async Task SeedOrganizersAsync(ApplicationDbContext dbContext)
    {
        if (!dbContext.Organizers.Any())
        {
            dbContext.Organizers.AddRange(
                new Organizer { Name = "Event Co.", Email = "info@eventco.com", ContactNumber = "1234567890" },
                new Organizer { Name = "Festivals Ltd.", Email = "contact@festivals.com", ContactNumber = "0987654321" },
                new Organizer { Name = "Concert Productions", Email = "hello@concertproductions.com", ContactNumber = "5551234567" },
                new Organizer { Name = "Showtime Events", Email = "info@showtimeevents.com", ContactNumber = "5559876543" },
                new Organizer { Name = "Elite Promotions", Email = "contact@elitepromotions.com", ContactNumber = "5553214567" },
                new Organizer { Name = "Event Masters", Email = "hello@eventmasters.com", ContactNumber = "5556543210" }
            );
            await dbContext.SaveChangesAsync();
        }
    }
    }
