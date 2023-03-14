using EmailPlanner_Alpha.Shared;

namespace EmailPlanner_Alpha.Server.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly DataContext _context;

        public TicketService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Ticket>>> AddTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return new ServiceResponse<List<Ticket>> { Success = true };
        }

        public async Task<ServiceResponse<List<Ticket>>> DeleteTicket(int ticketId)
        {
            var dbTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
            if (dbTicket == null)
            {
                return new ServiceResponse<List<Ticket>>
                {
                    Success = false,
                    Message = "Ticket not found."
                };
            }
            else
            {
                dbTicket.Deleted = true;
                await _context.SaveChangesAsync();
                return new ServiceResponse<List<Ticket>> { Success = true };
            }
        }

        public async Task<ServiceResponse<List<Ticket>>> GetAdminTickets()
        {
            var result = await _context.Tickets
                .Include(t => t.Email)
                .Include(t => t.Completion)
                .Include(t => t.Priority)
                .Include(t => t.User)
                .ToListAsync();
            return new ServiceResponse<List<Ticket>>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<Ticket>> GetTicketById(int ticketId)
        {
            var dbTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
            if (dbTicket == null)
            {
                return new ServiceResponse<Ticket> 
                { 
                    Success = false,
                    Message = "Ticket not found."
                };
            }
            else
            {
                return new ServiceResponse<Ticket>
                {
                    Data = dbTicket,
                    Success = true
                };
            }
        }

        public async Task<ServiceResponse<List<Ticket>>> GetTickets()
        {
            var result = await _context.Tickets
                .Include(t => t.Email)
                .Include(t => t.Completion)
                .Include(t => t.Priority)
                .Include(t => t.User)
                .Where(t => t.Deleted == false).ToListAsync();
            return new ServiceResponse<List<Ticket>>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<List<Ticket>>> UpdateTicket(Ticket ticket)
        {
            var dbTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticket.Id);
            if (dbTicket == null)
            {
                return new ServiceResponse<List<Ticket>>
                {
                    Success = false,
                    Message = "Ticket not found."
                };
            }
            else
            {
                dbTicket.Email = ticket.Email;
                dbTicket.Priority = ticket.Priority;
                dbTicket.User = ticket.User;
                dbTicket.Completion = ticket.Completion;
                dbTicket.Deleted = ticket.Deleted;

                await _context.SaveChangesAsync();
                return new ServiceResponse<List<Ticket>> { Success = true };
            }
        }
    }
}
