using EmailPlanner_Alpha.Shared;

namespace EmailPlanner_Alpha.Server.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly DataContext _context;

        public EmailService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Email>>> AddEmail(Email email)
        {
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();
            return new ServiceResponse<List<Email>> { Success = true };
        }

        public async Task<ServiceResponse<List<Email>>> DeleteEmail(int emailId)
        {
            var dbEmail = await _context.Emails.FirstOrDefaultAsync(e => e.Id == emailId);
            if (dbEmail == null)
            {
                return new ServiceResponse<List<Email>> { Success = false, Message = "Email not found." };
            }
            else
            {
                dbEmail.Deleted = true;
                await _context.SaveChangesAsync();
                return new ServiceResponse<List<Email>> { Success = true };
            }
        }

        public async Task<ServiceResponse<int>> GetAdminEmailCount()
        {
            var result = await _context.Emails.CountAsync();
            return new ServiceResponse<int>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<List<Email>>> GetAdminEmails()
        {
            var result = await _context.Emails
                .Include(e => e.Ticket)
                .ThenInclude(t => t.Completion)
                .OrderByDescending(e => e.DateRecieved).ToListAsync();
            return new ServiceResponse<List<Email>>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<Email>> GetEmailById(int emailId)
        {
            var result = await _context.Emails.FirstOrDefaultAsync(e => e.Id == emailId);
            return new ServiceResponse<Email>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<int>> GetEmailCount()
        {
            var result = await _context.Emails.Where(e => e.Deleted == false).CountAsync();
            return new ServiceResponse<int>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<List<Email>>> GetEmails()
        {
            var result = await _context.Emails
                .Include(e => e.Ticket)
                .ThenInclude(t => t.Completion)
                .Where(e => e.Deleted == false).OrderByDescending(e => e.DateRecieved).ToListAsync();
            return new ServiceResponse<List<Email>>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<int>> GetMaxEmailID()
        {
            var result = await _context.Emails.MaxAsync(e => e.Id);
            return new ServiceResponse<int>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<List<Email>>> UpdateEmail(Email email)
        {
            var dbEmail = await _context.Emails.FirstOrDefaultAsync(e => e.Id == email.Id);
            if (dbEmail == null)
            {
                return new ServiceResponse<List<Email>> { Success = false, Message = "Email not found." };
            }
            else
            {
                dbEmail.Sender = email.Sender;
                dbEmail.Body = email.Body;
                dbEmail.Subject = email.Subject;
                dbEmail.DateRecieved = email.DateRecieved;
                dbEmail.Deleted = email.Deleted;

                await _context.SaveChangesAsync();
                return new ServiceResponse<List<Email>> { Success = true };
            }
        }
    }
}
