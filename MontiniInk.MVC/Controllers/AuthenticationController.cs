using Microsoft.AspNetCore.Mvc;
using System;
using MontiniInk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MontiniInk
{
    public class AuthenticationController: Controller
    {
        private IRepository Repository;
        private ILogger<AuthenticationController> logger;

        public AuthenticationController(ILogger<AuthenticationController> logger, IRepository Repository){
            this.Repository= Repository;
            this.logger= logger;
        }
        public IActionResult Index()
        {
            return Redirect("/Authentication/Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetInt32("user_ID", 0);
            return Redirect("/Authentication/Login");
        }


        public IActionResult CheckCredentials([FromForm] LoginModel login)
        {
            var User= Repository.Users.findbyEmailandPassword(login);
            
            if(User==null)
            {
                ModelState.AddModelError("", "User not found");
                logger.LogWarning("Login unsuccessfull");
                return View("Login", login);
            }
            HttpContext.Session.SetInt32("user_ID", User.ID);            
            logger.LogInformation("Login successfull "+ User.lastname + " with ID: " + User.ID.ToString());
            return Redirect("/Home/Index");
        }
        
    }
}