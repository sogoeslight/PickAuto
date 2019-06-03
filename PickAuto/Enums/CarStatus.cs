using System.ComponentModel.DataAnnotations;

public enum CarStatus
{
    [Display(Name = "Avvailable")]
    Available,
    [Display(Name = "In Rental")]
    InRental,
    [Display(Name = "Sold")]
    Sold
}