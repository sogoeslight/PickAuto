﻿using System.ComponentModel.DataAnnotations;

public enum FuelType
{
    [Display(Name = "Petrol")]
    Petrol,
    [Display(Name = "Diesel")]
    Diesel,
    [Display(Name = "Electric")]
    Electric,
    [Display(Name = "Gas")]
    Gas
}