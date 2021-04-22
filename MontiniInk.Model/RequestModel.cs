using System;
using System.ComponentModel.DataAnnotations;

namespace MontiniInk.Model


{
   public class RequestModel
   {


       [Required]
       [StringLength(50)]
       public string firstname { get; set; }
       
       [Required]
       [StringLength(50)]       
       public string lastname { get; set; }

       [Required]
       [EmailAddress]
       public string Email { get; set; }    
    
       [Required]
       [MinLength(25, ErrorMessage= "Bitte sei etwas genauer")]
       public string Idea { get; set; } 
 
   } 
}