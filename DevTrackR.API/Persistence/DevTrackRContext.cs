using DevTrackR.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrackR.API.Persistence
{
    public class DevTrackRContext : DbContext
    {
        public DbSet<Package> Packages { get; set; }

        public DbSet<PackageUpdate> PackageUpdates { get; set; }

        public DevTrackRContext(DbContextOptions<DevTrackRContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>(p =>
            {
                p.HasMany(p => p.Updates)
                    .WithOne()
                    .HasForeignKey(p => p.PackageId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}