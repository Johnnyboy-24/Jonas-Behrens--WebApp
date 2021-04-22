using System;
using System.ComponentModel.DataAnnotations;

namespace MontiniInk.Model
{
    public class MyDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)// Return a boolean value: true == IsValid, false != IsValid
    {
        
        DateTime d = Convert.ToDateTime(value);
        if(d >= DateTime.Now) 
            return ValidationResult.Success; //Dates Greater than or equal to today are valid (true)
        return new ValidationResult(ErrorMessage="Nur zuküntige Daten erlaubt");
    }
}
}