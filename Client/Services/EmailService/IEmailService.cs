using EmailPlanner_Alpha.Shared;

namespace EmailPlanner_Alpha.Client.Services.EmailService
{
    public interface IEmailService
    {
        List<Email> Emails { get; set; }
        Email Email { get; set; }
        int EmailCount { get; set; }
        Task GetEmails();
        Task GetAdminEmails();
        Task GetEmailById(int emailId);
        Task GetEmailCount();
        Task GetAdminEmailCount();
        Task GetMaxEmailID();
        Task DeleteEmail(int emailId);
        Task AddEmail(Email email);
        Task UpdateEmail(Email email);
    }
}
