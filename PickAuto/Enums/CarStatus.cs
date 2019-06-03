using System.ComponentModel.DataAnnotations;

public enum CarStatus
{
    [Display(Name = "Available")]
    Available,
    [Display(Name = "In Rental")]
    InRental,
    [Display(Name = "Sold")]
    Sold
}