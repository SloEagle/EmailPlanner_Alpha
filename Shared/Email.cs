using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailPlanner_Alpha.Shared
{
    public class Email
    {
        public int Id { get; set; }
        public string Sender { get; set; } = string.Empty;
        public string? Subject { get; set; } = string.Empty;
        public string? Body { get; set; } = string.Empty;
        public DateTime DateRecieved { get; set; } = DateTime.Now;
        public string? Bcc { get; set; } = string.Empty;
        public string? Cc { get; set; } = string.Empty;
        public int? RepliedToID { get; set; } = null;
        public Ticket? Ticket { get; set; } = null;
        public string TicketStarted { get; set; } = "false";
        public bool Deleted { get; set; } = false;
    }
}
