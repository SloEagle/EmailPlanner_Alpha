using EmailPlanner_Alpha.Shared;
using System.Net.Http.Json;

namespace EmailPlanner_Alpha.Client.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _http;

        public TicketService(HttpClient http)
        {
            _http = http;
        }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public Ticket Ticket { get; set; } = new Ticket();

        public async Task AddTicket(Ticket ticket)
        {
            await _http.PostAsJsonAsync("api/ticket", ticket);
        }

        public async Task DeleteTicket(int ticketId)
        {
            await _http.DeleteAsync($"api/ticket/{ticketId}");
        }

        public async Task GetAdminTickets()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Ticket>>>("api/ticket/admin");
            Tickets = response.Data;
        }

        public async Task GetTicketById(int ticketId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Ticket>>($"api/ticket/{ticketId}");
            Ticket = response.Data;
        }

        public async Task GetTickets()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Ticket>>>("api/ticket");
            Tickets = response.Data;
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            await _http.PutAsJsonAsync("api/ticket", ticket);
        }
    }
}
