using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailPlanner_Alpha.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role? Role { get; set; } = null;
        public Company? Company { get; set; } = null;
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
}
