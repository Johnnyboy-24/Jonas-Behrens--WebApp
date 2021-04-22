using System;
using System.ComponentModel.DataAnnotations;

namespace MontiniInk.Model


{
   public class Request: Entity
   {

       public string Anfrage { get; set; }

       public int UserId { get; set; }     

       public DateTime Appointment{get; set;}

       public bool Handled { get; set; }

       public Request(string Anfrage, int UserId)
       {
           this.Anfrage= Anfrage;
           this.UserId= UserId;
           Handled= false;        
           
       }
 
   } 
}