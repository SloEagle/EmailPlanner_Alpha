using EmailPlanner_Alpha.Shared;

namespace EmailPlanner_Alpha.Server.Services.TicketService
{
    public interface ITicketService
    {
        Task<ServiceResponse<List<Ticket>>> GetTickets();
        Task<ServiceResponse<List<Ticket>>> GetAdminTickets();
        Task<ServiceResponse<Ticket>> GetTicketById(int ticketId);
        Task<ServiceResponse<List<Ticket>>> UpdateTicket(Ticket ticket);
        Task<ServiceResponse<List<Ticket>>> AddTicket(Ticket ticket);
        Task<ServiceResponse<List<Ticket>>> DeleteTicket(int ticketId);
    }
}
