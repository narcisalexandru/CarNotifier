using Microsoft.AspNetCore.Mvc;
using CarRegistrationApi.Services;
using CarRegistrationApi.Models;
using System.Threading.Tasks;
using CarRegistrationApi.Data;

namespace CarRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public RegistrationController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationModel registration)
        {
            if (registration == null)
            {
                return BadRequest();
            }

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            _emailService.SendConfirmationEmail(registration.Email, registration.FullName, registration.LicensePlate, registration.Service, registration.ExpiryDate);

            return Ok();
        }
    }
}
