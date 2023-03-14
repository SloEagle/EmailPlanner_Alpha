using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailPlanner_Alpha.Shared
{
    public class Ticket
    {
        public int Id { get; set; }
        public Email? Email { get; set; } = null;
        public Priority? Priority { get; set; } = null;
        public User? User { get; set; } = null;
        public Completion? Completion { get; set; } = null;
    }
}
