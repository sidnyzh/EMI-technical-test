using EMI.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EMI.Repository.EFC
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }

        public DbSet<RequestLog> RequestLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.RequestBody).HasMaxLength(5000);
                entity.Property(e => e.RequestMethod).HasMaxLength(10);
                entity.Property(e => e.RequestPath).HasMaxLength(200);
                entity.Property(e => e.QueryString).HasMaxLength(500);
                entity.Property(e => e.Identifier).HasMaxLength(20);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
