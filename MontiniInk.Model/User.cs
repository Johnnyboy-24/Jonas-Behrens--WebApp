using System;
using System.ComponentModel.DataAnnotations;

namespace MontiniInk.Model


{
   public class User: Entity{


       public User(string firstname, string lastname, string Email)
       {
           this.firstname= firstname;
           this.lastname= lastname;
           this.isAdmin= false;
           this.Email= Email;
       }
       public User(string firstname, string lastname, string Email,  string Password)
       {
           this.firstname= firstname;
           this.lastname= lastname;
           this.isAdmin= true;
           this.Email= Email;
           this.Password=Password;
       }
       [Required]
       [StringLength(50)]
       public string firstname { get; set; }
       
       [Required]
       [StringLength(50)]       
       public string lastname { get; set; }
       public bool isAdmin { get; set; }

       [Required]
       [EmailAddress]
       public string Email { get; set; }

       [DataType(DataType.Password)]       
       public string Password {get; set;}
       

    
       public string role(){
           if(isAdmin==true)
                return "Artist";

            else return "Kunde";
       }

        
 
   } 
}