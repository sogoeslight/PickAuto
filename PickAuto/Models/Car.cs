using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RentalPrice { get; set; }
    }
}
