using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [Required]
        [Display(Name = "Model")]
        public int CarModelId { get; set; }
        [Display(Name = "Model")]
        public CarModel CarModel { get; set; }

        [Required]
        [Range(0, 999999)]
        public long Mileage { get; set; }

        [Required]
        [Display(Name = "Business Segment")]
        [EnumDataType(typeof(BusinessSegment))]
        public BusinessSegment BusinessSegment { get; set; }

        [Required]
        [Display(Name = "Status")]
        [EnumDataType(typeof(CarStatus))]
        public CarStatus CarStatus { get; set; }
    }
}
