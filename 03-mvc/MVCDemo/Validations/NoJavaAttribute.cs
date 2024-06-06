
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Validations;

public class NoJavaAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        // Your logic to check validation (A lot of the time you may have cast it because value is an Object!)
        if (((string)value)?.Contains("Java") == true) // optional chaining : continue if it is not null
        {         
            return new ValidationResult("You cannot talk about Java here!");   // validation message
        } else {   
            return ValidationResult.Success;  // passed the validation, it is valid
        }  
    }
}
