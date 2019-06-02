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



        [Display(Name = "Gearbox")]
        public int GearboxId { get; set; }
        public Gearbox Gearbox { get; set; }
        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        [Display(Name = "Wheel Drive")]
        public int WheelDriveId { get; set; }
        public WheelDrive WheelDrive { get; set; }
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
