using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PickAuto.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public Manufacturer Manufacturer { get; set; }
        [Required]
        public CarModel Model { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionYear { get; set; }
        [Required]
        public long Mileage { get; set; }
        [Required]
        public short Seats { get; set; }
        [Required]
        public FuelType FuelType { get; set; }
        [Required]
        public Gearbox Gearbox { get; set; }
        [Required]
        public WheelDrive WheelDrive { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal RentalPrice { get; set; }
    }
}
