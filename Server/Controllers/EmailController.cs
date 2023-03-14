using EmailPlanner_Alpha.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailPlanner_Alpha.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Email>>>> GetEmails()
        {
            var result = await _emailService.GetEmails();
            return Ok(result);
        }

        [HttpGet("admin")]
        public async Task<ActionResult<ServiceResponse<List<Email>>>> GetAdminEmails()
        {
            var result = await _emailService.GetAdminEmails();
            return Ok(result);
        }

        [HttpGet("{emailId:int}")]
        public async Task<ActionResult<ServiceResponse<Email>>> GetEmailById(int emailId)
        {
            var result = await _emailService.GetEmailById(emailId);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetEmailCount()
        {
            var result = await _emailService.GetEmailCount();
            return Ok(result);
        }

        [HttpGet("admin-count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetAdminEmailCount()
        {
            var result = await _emailService.GetAdminEmailCount();
            return Ok(result);
        }

        [HttpGet("max-id")]
        public async Task<ActionResult<ServiceResponse<int>>> GetMaxEmailId()
        {
            var result = await _emailService.GetMaxEmailID();
            return Ok(result);
        }

        [HttpDelete("{emailId:int}")]
        public async Task<ActionResult<ServiceResponse<List<Email>>>> DeleteEmail(int emailId)
        {
            var result = await _emailService.DeleteEmail(emailId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Email>>>> AddEmail(Email email)
        {
            var result = await _emailService.AddEmail(email);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Email>>>> UpdateEmail(Email email)
        {
            var result = await _emailService.UpdateEmail(email);
            return Ok(result);
        }
    }
}
