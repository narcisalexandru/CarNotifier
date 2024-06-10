using Microsoft.AspNetCore.Mvc;
using CarRegistrationApi.Models;
using CarRegistrationApi.Services;
using CarRegistrationApi.Data;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Register([FromBody] RegistrationModel registration)
        {
            if (registration == null)
            {
                return BadRequest();
            }

            _context.Registrations.Add(registration);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Eroare internă a serverului: {ex.Message}");
            }

            // Trimite emailul de confirmare cu detaliile înregistrării
            _emailService.SendConfirmationEmail(registration.Email, registration.FullName, registration.LicensePlate, registration.Service, registration.ExpiryDate);

            return Ok(new { message = "Înregistrarea a fost realizată cu succes și emailurile de notificare au fost trimise." });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationModel>>> GetRegistrations()
        {
            return await _context.Registrations.ToListAsync();
        }
    }
}
