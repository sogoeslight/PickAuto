using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PickAuto.Models
{
    public class PickAutoContext : DbContext
    {
        public PickAutoContext(DbContextOptions<PickAutoContext> options)
            : base(options)
        {
        }

        public DbSet<PickAuto.Models.Address> Address { get; set; }
        public DbSet<PickAuto.Models.Car> Car { get; set; }
        public DbSet<PickAuto.Models.CarModel> CarModel { get; set; }
        public DbSet<PickAuto.Models.City> City { get; set; }
        public DbSet<PickAuto.Models.Country> Country { get; set; }
        public DbSet<PickAuto.Models.Customer> Customer { get; set; }
        public DbSet<PickAuto.Models.ErrorViewModel> ErrorViewModel { get; set; }
        public DbSet<PickAuto.Models.FuelType> FuelType { get; set; }
        public DbSet<PickAuto.Models.Gearbox> GearBox { get; set; }
        public DbSet<PickAuto.Models.Manufacturer> Manufacturer { get; set; }
        public DbSet<PickAuto.Models.Payment> Payment { get; set; }
        public DbSet<PickAuto.Models.Rental> Rental { get; set; }
        public DbSet<PickAuto.Models.Staff> Staff { get; set; }
        public DbSet<PickAuto.Models.Store> Store { get; set; }
        public DbSet<PickAuto.Models.WheelDrive> WheelDrive { get; set; }
    }
}