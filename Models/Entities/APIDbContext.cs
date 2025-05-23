using Microsoft.EntityFrameworkCore;

namespace EventCalender.Models.Entities
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> user { get; set; }
    }
}
