#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using MVCDemo.Validations;

namespace MVCDemo.Models;

public class Entry
{
    [Required]
    [Display(Name ="Full Name")]
    [MinLength(3, ErrorMessage ="Full Name must be at least 3 characters long")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "Special Characters are not allowed.")]
    [NoZNames]
    public string FullName{get; set;}

    [Required]
    [Range(1, 100)] // If you want the max to be the max, Int32.MaxValue
    public int? Age{get; set;}

    public string Horoscope{get; set;}

    [Required]
    [MinLength(3)]
    [NoJava]
    public string? Introduction{get; set;}
}


public class NoZNamesAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        // Your logic to check validation (A lot of the time you may have cast it because value is an Object!)
        if (value == null || ((string)value).ToLower()[0] == 'z')
        {         
            return new ValidationResult("No names that start with Z allowed!");   // validation message
        } else {   
            return ValidationResult.Success;  // passed the validation, it is valid
        }  
    }
}
