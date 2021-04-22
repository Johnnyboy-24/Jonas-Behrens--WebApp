using Microsoft.AspNetCore.Mvc;
using System;
using MontiniInk.Model;
namespace MontiniInk
{ 
    public class HomeController: Controller
    {
        private IRepository repository; 
        public HomeController(IRepository repository)
        {
          this.repository= repository;
        }
        public IActionResult Index(){
          var Posts= repository.BlogPosts.Latest(1);
          return View(Posts); 
        }

    }
}

