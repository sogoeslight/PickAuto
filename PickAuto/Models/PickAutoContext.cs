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
        public DbSet<ErrorViewModel> ErrorViewModel { get; set; }
        public DbSet<FuelType> FuelType { get; set; }
        public DbSet<Gearbox> GearBox { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<WheelDrive> WheelDrive { get; set; }
    }
}