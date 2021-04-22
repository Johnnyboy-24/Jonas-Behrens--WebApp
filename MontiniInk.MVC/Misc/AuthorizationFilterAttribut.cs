
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MontiniInk.Model;

namespace MontiniInk.Misc
{ 
    public class AuthorizationFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)//If attatched to IActionresult, Checks for logged in User
        {
            
            
            if(((context.HttpContext.Session.GetInt32("user_ID")==null)||(context.HttpContext.Session.GetInt32("user_ID")==0)))
            {            
                context.Result =new RedirectResult("/Authentication/Login");
                
            }
        }
    }
}
