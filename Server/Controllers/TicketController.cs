using EmailPlanner_Alpha.Server.Services.TicketService;
using EmailPlanner_Alpha.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailPlanner_Alpha.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Ticket>>>> GetTickets()
        {
            var result = await _ticketService.GetTickets();
            return Ok(result);
        }

        [HttpGet("admin")]
        public async Task<ActionResult<ServiceResponse<List<Ticket>>>> GetAdminTickets()
        {
            var result = await _ticketService.GetAdminTickets();
            return Ok(result);
        }

        [HttpGet("{ticketId:int}")]
        public async Task<ActionResult<ServiceResponse<Ticket>>> GetTicketById(int ticketId)
        {
            var result = await _ticketService.GetTicketById(ticketId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Ticket>>>> UpdateTicket(Ticket ticket)
        {
            var result = await _ticketService.UpdateTicket(ticket);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Ticket>>>> AddTicket(Ticket ticket)
        {
            var result = await _ticketService.AddTicket(ticket);
            return Ok(result);
        }

        [HttpDelete("{ticketId}")]
        public async Task<ActionResult<ServiceResponse<List<Ticket>>>> DeleteTicket(int ticketId)
        {
            var result = await _ticketService.DeleteTicket(ticketId);
            return Ok(result);
        }


    }
}
