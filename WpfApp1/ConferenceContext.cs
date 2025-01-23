using System.Data.Entity;

namespace ConferenceManagementSystem.Models
{
    public class ConferenceContext : DbContext
    {
        public ConferenceContext() : base("name=ConferenceContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
    }
}