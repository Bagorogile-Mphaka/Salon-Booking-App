using Microsoft.EntityFrameworkCore;

using SalonBookingApp1.Models;

namespace SalonBookingApp1
{
    public class SalonBookingAppDbContext : DbContext
    {

        //Constructor
        public SalonBookingAppDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
            //Tables (DbSets)
            public DbSet<Client> Clients { get; set; }
        public DbSet<Stylist> Stylist { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relationships
            //One client can have many bookings
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Client)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.ClientId);

            //One stylist can have many bookings
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Stylist)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.StylistId);

            //One treatment can have many bookings
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Treatment)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.TreatmentId);


        }
    
    }
}
