using EmailPlanner_Alpha.Shared;
using MailKit.Net.Imap;
using MailKit;

namespace EmailPlanner_Alpha.Server.Background_Services
{
    public class EmailRetrievalService : BackgroundService
    {
        private readonly ILogger<EmailRetrievalService> _logger;
        private readonly IServiceProvider _services;
        private readonly IConfiguration _configuration;

        public EmailRetrievalService(ILogger<EmailRetrievalService> logger, IServiceProvider services, IConfiguration configuration)
        {
            _logger = logger;
            _services = services;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Data background service is starting.");

            stoppingToken.Register(() =>
                _logger.LogInformation("Data background service is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Data background service is doing background work.");

                // Use a scope to access your data context
                using (var scope = _services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                    await FillEmailServer(dbContext);
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }

            _logger.LogInformation("Data background service has stopped.");
        }

        public async Task FillEmailServer(DataContext _context)
        {
            using (var client = new ImapClient())
            {
                var address = _configuration.GetValue<string>("SMTP:Address");
                var port = _configuration.GetValue<int>("SMTP:Port");
                var user = _configuration.GetValue<string>("SMTP:User");
                var password = _configuration.GetValue<string>("SMTP:Password");

                client.Connect(address, port, true);
                client.Authenticate(user, password);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                if (_context.Emails.Count() == 0)
                {
                    if (inbox != null)
                    {
                        var message = inbox.GetMessage(inbox.Count - 1);
                        _context.Emails.Add(new Email { Sender = message.From.ToString(), Subject = message.Subject, Body = message.HtmlBody.ToString(), DateRecieved = message.Date.LocalDateTime });
                    }
                }
                else
                {
                    var lastEmail = await _context.Emails.OrderByDescending(e => e.DateRecieved).FirstOrDefaultAsync();
                    if (lastEmail != null)
                    {
                        var lastEmailDate = lastEmail.DateRecieved;

                        if (inbox != null)
                        {
                            for (var i = inbox.Count - 1; i >= 0; i--)
                            {
                                var message = inbox.GetMessage(i);

                                if (message.Date.LocalDateTime > lastEmailDate)
                                {
                                    _context.Emails.Add(new Email { Sender = message.From.ToString(), Subject = message.Subject, Body = message.HtmlBody.ToString(), DateRecieved = message.Date.LocalDateTime });
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                client.Disconnect(true);

                await _context.SaveChangesAsync();
            }
        }

    }
}
