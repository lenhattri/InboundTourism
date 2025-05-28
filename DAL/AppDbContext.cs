using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TourLocation> TourLocations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set khóa chính cho bảng TourLocation (composite key)
            modelBuilder.Entity<TourLocation>()
                .HasKey(tl => new { tl.TourID, tl.LocationID, tl.LocationIndex });
        }
    }
}
