using EmailPlanner_Alpha.Shared;

namespace EmailPlanner_Alpha.Client.Services.TicketService
{
    public interface ITicketService
    {
        List<Ticket> Tickets { get; set; }
        Ticket Ticket { get; set; }
        Task GetTickets();
        Task GetAdminTickets();
        Task GetTicketById(int ticketId);
        Task UpdateTicket(Ticket ticket);
        Task AddTicket(Ticket ticket);  
        Task DeleteTicket(int ticketId);
    }
}
