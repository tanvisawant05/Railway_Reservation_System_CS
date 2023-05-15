using Microsoft.EntityFrameworkCore;
using Railway_Reservation_System_CS.Models;

namespace Railway_Reservation_System_CS.Data
{
    public class RailwayContext : DbContext
    {
        public RailwayContext(DbContextOptions<RailwayContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seat> Seats { get; set; }

    }
}
