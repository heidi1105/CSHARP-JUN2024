#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models;

public class Entry
{
    [Required]
    [Display(Name ="Full Name")]
    [MinLength(3, ErrorMessage ="Full Name must be at least 3 characters long")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "Special Characters are not allowed.")]
    public string FullName{get; set;}

    [Required]
    [Range(1, 100)] // If you want the max to be the max, Int32.MaxValue
    public int? Age{get; set;}

    public string Horoscope{get; set;}

    [Required]
    [MinLength(3)]
    public string? Introduction{get; set;}
}