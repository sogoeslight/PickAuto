using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Year")]
        public DateTime ProductionYear { get; set; }

        [Required]
        [Range(1, 70)]
        [Display(Name = "Seats")]
        public int NumberOfSeats { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public FuelType FuelType { get; set; }

        [Required]
        [Display(Name = "Gearbox")]
        public int GearboxId { get; set; }
        public Gearbox Gearbox { get; set; }

        [Required]
        [Range(0, 12)]
        [Display(Name = "Seats")]
        public int EngineLiters { get; set; }

        [Required]
        [Display(Name = "Wheel Drive")]
        public WheelDrive WheelDrive { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
