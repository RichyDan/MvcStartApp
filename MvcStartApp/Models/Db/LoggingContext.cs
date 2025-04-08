using Microsoft.EntityFrameworkCore;

namespace MvcStartApp.Models.Db
{
    public class LoggingContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public LoggingContext(DbContextOptions<LoggingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
