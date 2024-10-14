
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace DAL
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TourLocation> TourLocations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Thiết lập khóa chính và khóa ngoại cho bảng trung gian TourLocation
            modelBuilder.Entity<TourLocation>()
                .HasKey(tl => new { tl.TourID, tl.LocationID });

            modelBuilder.Entity<TourLocation>()
                .HasOne(tl => tl.Tour)
                .WithMany(t => t.TourLocations)
                .HasForeignKey(tl => tl.TourID);

            modelBuilder.Entity<TourLocation>()
                .HasOne(tl => tl.Location)
                .WithMany(l => l.TourLocations)
                .HasForeignKey(tl => tl.LocationID);
        }
    }

}
