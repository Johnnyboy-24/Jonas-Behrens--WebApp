using Microsoft.AspNetCore.Mvc;
using System;
using MontiniInk.Model;
using Microsoft.AspNetCore.Http;

namespace MontiniInk
{ 
    public class KontaktController: Controller
    {
      
      private IRepository Repository;

      public KontaktController(IRepository Repository)
      {
        this.Repository= Repository;
        
      }
      public IActionResult Index()
      {    
        
        return View(); 
      }
      public IActionResult Saved()
      {
        var Person= Repository.Users.ById((int)HttpContext.Session.GetInt32("Saved_User"));
        return View(Person);
      }
      
      public IActionResult RequestHandler([FromForm] RequestModel request)
      {
        User u= Repository.Users.findbyEmail(request.Email);
        if(u==null)
        {
          u= new User(request.firstname, request.lastname, request.Email);
          Repository.Users.Save(u);
        }
        var r= new Request(request.Idea,u.ID);
        Repository.Requests.Save(r);
        HttpContext.Session.SetInt32("Saved_User", u.ID);
        return RedirectToAction("Saved");
      }
    }
}

