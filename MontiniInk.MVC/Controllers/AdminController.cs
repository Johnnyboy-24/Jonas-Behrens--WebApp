using Microsoft.AspNetCore.Mvc;
using System;
using MontiniInk.Model;
using MontiniInk.Misc;
using SimpleHashing.Net;
using Microsoft.Extensions.Logging;

namespace MontiniInk
{ 
    public class AdminController: Controller
    {
      public IRepository Repository;
      private ILogger<AdminController> logger;
      public AdminController(ILogger<AdminController> logger, IRepository Repository)
      {
        this.Repository = Repository;
        this.logger= logger;
      }

      [AuthorizationFilter()]
      public IActionResult Index()
      {    
        var Helper = new CalendarHelper(Repository);
        return View(Helper); 
      }

      [AuthorizationFilter()]
      public IActionResult Save(int id, [FromForm] CalendarHelper helper) //Checks wether enough & valid data(DateTime) is passed. If so, the request's data is updated an stored.
      {
        if(!ModelState.IsValid)
        {
          ModelState.AddModelError("","Nur zukünftige Daten Erlaubt");
          helper.Repository= Repository;
          return View("Index", helper); 

        }
        if(Repository.Requests.ByDate(helper.Date) !=null)
        {
          ModelState.AddModelError("","Dieser Tag ist schon belegt");
          helper.Repository= Repository;
          return View("Index", helper); 
        }

        var request = Repository.Requests.ById(id);
        request.Handled=true;
        request.Appointment= helper.Date;
        Repository.Requests.Save(request);
        logger.LogInformation("Anfrage erfolgreich bearbeitet");
        var Person = Repository.Users.ById(request.UserId);
        SMTP.send(Person.Email, Person.firstname, request.Appointment, SMTP.MailType.Declared);
        return Redirect("/Admin/Index");
      }

      [AuthorizationFilter()]
      public IActionResult Cancel(int id)//Removes according request from the repository
      {
        var request = Repository.Requests.ById(id);  
        var Person = Repository.Users.ById(request.UserId);
        SMTP.send(Person.Email, Person.firstname, request.Appointment, SMTP.MailType.Cancelled);  
        Repository.Requests.Delete(id);
        logger.LogInformation("Anfrage erfolgreich gelöscht");
        return Redirect("/Admin/Index");
      }
      
      [AuthorizationFilter()]
      public IActionResult Reschedule(int id) //The request is marked as "unhandled". Now we can attach a new Date Time in our form from Views/Admin/Index
      {
        var request = Repository.Requests.ById(id);
        request.Handled= false;  
        var Person = Repository.Users.ById(request.UserId);
        SMTP.send(Person.Email, Person.firstname, request.Appointment, SMTP.MailType.Rescheduled);  
        Repository.Requests.Save(request);
        logger.LogInformation("Anfrage mit ID: " + request.ID + " für neuen Termin vorbereitet");
        return Redirect("/Admin/Index");
      }

    }
}

