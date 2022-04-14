using Microsoft.EntityFrameworkCore;
using PricefyChallenge.Core.Entities;

namespace PricefyChallenge.Infra.Data
{
    public class PricefyContext : DbContext
    {
        public PricefyContext(DbContextOptions<PricefyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                        .HasOne(s => s.MovieAttachment)
                        .WithMany(g => g.Movies)
                        .HasForeignKey(s => s.MovieAttachmentId);
        }


        public DbSet<MovieAttachment> MovieAttachments { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
