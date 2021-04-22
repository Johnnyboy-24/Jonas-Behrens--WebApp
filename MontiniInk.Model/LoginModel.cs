using System.ComponentModel.DataAnnotations;

namespace MontiniInk.Model
{
    public class LoginModel
    {
        
       [Required]
       [EmailAddress]
       public string Email { get; set; }

       [Required]
       [MinLength(5)]
       [DataType(DataType.Password)]

       public string Passwort { get; set; }
    }
}