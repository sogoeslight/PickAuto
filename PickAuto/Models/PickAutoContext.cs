using Microsoft.EntityFrameworkCore;

namespace PickAuto.Models
{
    public class PickAutoContext : DbContext
    {
        public PickAutoContext(DbContextOptions<PickAutoContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<FuelType> FuelType { get; set; }
        public DbSet<Gearbox> GearBox { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<WheelDrive> WheelDrive { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<CarStatus> CarStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(p => p.Rental)
                .WithOne(i => i.Car)
                .HasForeignKey<Rental>(b => b.CarForeignKey);
            modelBuilder.Entity<Car>()
                .HasOne(p => p.Purchase)
                .WithOne(i => i.Car)
                .HasForeignKey<Purchase>(b => b.CarForeignKey);
        }
    }
}