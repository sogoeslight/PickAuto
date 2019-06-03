using Microsoft.EntityFrameworkCore;
using System;

namespace PickAuto.Models
{
    public class PickAutoContext : DbContext
    {
        public PickAutoContext(DbContextOptions<PickAutoContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Gearbox> GearBox { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

     }
}