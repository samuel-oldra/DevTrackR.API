using DevTrackR.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrackR.API.Persistence
{
    public class DevTrackRContext : DbContext
    {
#pragma warning disable CS8618

        public DevTrackRContext(DbContextOptions<DevTrackRContext> options) : base(options) { }

#pragma warning restore CS8618

        public DbSet<Package> Packages { get; set; }

        public DbSet<PackageUpdate> PackageUpdates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>(e =>
            {
                e.HasMany(p => p.Updates)
                    .WithOne()
                    .HasForeignKey(p => p.PackageId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}