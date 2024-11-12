using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EventManagementAPI.Models;
using EventManagementAPI.Models.Account;
using System.Threading.Tasks;
using System.Linq;
using EventManagementAPI.Data.Services;
using EventManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public AccountController(UserManager<ApplicationUser> userManager, ITokenService tokenService, ApplicationDbContext context, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest(new { Message = "Passwords do not match" });
            }

            // Check if the email is already registered
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest(new { Message = "Email is already registered" });
            }

            // Create ApplicationUser
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Assign the default role "User"
                await _userManager.AddToRoleAsync(user, "User");
                // Create Register entity with the same Id as ApplicationUser
                var register = new Register
                {
                    Id = user.Id, // Use the same Id as ApplicationUser
                    Username = model.Username,
                    Email = model.Email,
                    Password = _passwordHasher.HashPassword(user, model.Password) // Hash the password
                };
                _context.Registers.Add(register);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "User registered successfully" });
            }

            return BadRequest(result.Errors.Select(e => e.Description));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized(new { Message = "Invalid login attempt" });
            }

            // Create the token asynchronously
            var token = await _tokenService.CreateTokenAsync(user);

            // Get the user's roles asynchronously
            var roles = await _userManager.GetRolesAsync(user);

            // Create the response
            var response = new
            {
                Id = user.Id,
                Email = user.Email,
                Token = token,
                Role = roles.FirstOrDefault() // Assuming the user has one role
            };

            return Ok(response);
        }
        [HttpGet("registers")]
        public async Task<IActionResult> GetAllRegisters()
        {
            var registers = await _context.Registers.ToListAsync();
            return Ok(registers);
        }

        [HttpGet("registers/{id}")]
        public async Task<IActionResult> GetRegisterById(string id)
        {
            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound(new { Message = "Register not found" });
            }

            return Ok(register);
        }
    }
}

