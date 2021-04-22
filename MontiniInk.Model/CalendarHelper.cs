using System;
using System.ComponentModel.DataAnnotations;


namespace MontiniInk.Model
{
    public class CalendarHelper
    {
        
       public IRepository Repository { get; set; }

          
       
       [Required]
       [DataType(DataType.Date)]
       [MyDate]
       public DateTime Date { get; set; }
       public CalendarHelper(IRepository Repository) 
       {
           this.Repository= Repository;
           
       } 
        public CalendarHelper() 
       {
           
       }
    
       public string GetWeekday(int a)
       {
           a += (int)DateTime.Now.DayOfWeek;
           a= a%7;
           switch(a)
           {
               case 0: return "Sonntag"; 
               case 1: return "Montag"; 
               case 2: return "Dienstag"; 
               case 3: return "Mittwoch"; 
               case 4: return "Donnerstag";
               case 5: return "Freitag";
               default: return "Samstag";
           }
       }
    }
}