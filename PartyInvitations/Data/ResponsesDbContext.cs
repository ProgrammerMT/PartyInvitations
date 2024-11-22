using Microsoft.EntityFrameworkCore;
using PartyInvitations.Models;

namespace PartyInvitations.Data
{
    public class ResponsesDbContext : DbContext
    {
        public ResponsesDbContext(DbContextOptions<ResponsesDbContext> options) : base(options)
        {
        }

        public DbSet<GuestResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensures the Id is the primary key (optional, explicit configuration)
            modelBuilder.Entity<GuestResponse>()
                .HasKey(g => g.Id);
        }
    }
}
