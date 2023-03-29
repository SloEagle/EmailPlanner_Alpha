using EmailPlanner_Alpha.Shared;
using Org.BouncyCastle.Utilities.IO.Pem;

namespace EmailPlanner_Alpha.Server.Data
{ 
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Completion>().HasData(
                new Completion { Id = 1, Name = "Open" },
                new Completion { Id = 2, Name = "Pending" },
                new Completion { Id = 3, Name = "Solved" },
                new Completion { Id = 4, Name = "Reopened" },
                new Completion { Id = 5, Name = "On Hold" },
                new Completion { Id = 6 }
            );

            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, Name = "Low" },
                new Priority { Id = 2, Name = "Medium" },
                new Priority { Id = 3, Name = "High" },
                new Priority { Id = 4, Name = "Urgent" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Employee" }
            );
        }

        public DbSet<Email> Emails { get; set; }
        public DbSet<Completion> Completion { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<User> Users { get; set; }
    }
}
