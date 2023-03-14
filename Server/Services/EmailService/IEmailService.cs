using EmailPlanner_Alpha.Shared;

namespace EmailPlanner_Alpha.Server.Services.EmailService
{
    public interface IEmailService
    {
        Task<ServiceResponse<List<Email>>> GetEmails();
        Task<ServiceResponse<List<Email>>> GetAdminEmails();
        Task<ServiceResponse<Email>> GetEmailById(int emailId);
        Task<ServiceResponse<List<Email>>> UpdateEmail(Email email);
        Task<ServiceResponse<List<Email>>> AddEmail(Email email);
        Task<ServiceResponse<List<Email>>> DeleteEmail(int emailId);
        Task<ServiceResponse<int>> GetEmailCount();
        Task<ServiceResponse<int>> GetAdminEmailCount();
        Task<ServiceResponse<int>> GetMaxEmailID();

    }
}
