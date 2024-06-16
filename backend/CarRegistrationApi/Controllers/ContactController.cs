using Microsoft.AspNetCore.Mvc;
using CarRegistrationApi.Services;
using System.Threading.Tasks;
using CarRegistrationApi.Models;

namespace CarRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly EmailService _emailService;

        public ContactController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendContactMessage([FromBody] ContactMessageModel contactMessage)
        {
            if (contactMessage == null)
            {
                return BadRequest();
            }

            await _emailService.SendContactMessageAsync(contactMessage.Email, contactMessage.Subject, contactMessage.Message);

            return Ok();
        }
    }
}
