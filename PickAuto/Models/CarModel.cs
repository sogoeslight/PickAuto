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
        public DateTime ProductionYear { get; set; }
        [Required]
        [Range(1, 70)]
        public int NumberOfSeats { get; set; }



        public int GearboxId { get; set; }
        public Gearbox Gearbox { get; set; }
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        public int WheelDriveId { get; set; }
        public WheelDrive WheelDrive { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
