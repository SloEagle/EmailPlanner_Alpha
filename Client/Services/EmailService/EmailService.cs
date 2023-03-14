using EmailPlanner_Alpha.Shared;
using System.Net.Http.Json;

namespace EmailPlanner_Alpha.Client.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _http;

        public EmailService(HttpClient http)
        {
            _http = http;
        }

        public List<Email> Emails { get; set; } = new List<Email>();
        public Email Email { get; set; } = new Email();
        public int EmailCount { get; set; } = 0;

        public async Task AddEmail(Email email)
        {
            await _http.PostAsJsonAsync("api/email", email);
        }

        public async Task DeleteEmail(int emailId)
        {
            await _http.DeleteAsync($"api/email/{emailId}");
        }

        public async Task GetAdminEmailCount()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/email/admin-count");
            EmailCount = response.Data;
        }

        public async Task GetAdminEmails()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Email>>>("api/email/admin");
            Emails = response.Data;
        }

        public async Task GetEmailById(int emailId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Email>>($"api/email/{emailId}");
            Email = response.Data;
        }

        public async Task GetEmailCount()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/email/count");
            EmailCount = response.Data;
        }

        public async Task GetEmails()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Email>>>("api/email");
            Emails = response.Data;
        }

        public async Task GetMaxEmailID()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/email/max-id");
            EmailCount = result.Data;
        }

        public async Task UpdateEmail(Email email)
        {
            await _http.PostAsJsonAsync("api/email", email);
        }
    }
}
