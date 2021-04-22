using Microsoft.AspNetCore.Mvc;
using System;
using MontiniInk.Model;
using MontiniInk.Misc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MontiniInk
{ 
    public class BlogController: Controller
    {
        private IRepository repository; 
        private ILogger<BlogController> logger;
        private int CurrentPage;
        
        public BlogController(IRepository repository, ILogger<BlogController> logger)
        {
          this.repository= repository;
          this.logger= logger;
          CurrentPage= 1;
        }
        
        public IActionResult Index(int id)  //By default 3 Pages of Posts will be loaded. If not enough Posts are available repository.Blogpostst.Latest() will provide a default post.
        {
          if(id < 1)
            id=1;
          if(id > 3)
            id=3;                 
          var Posts= repository.BlogPosts.Latest(id);        
          return View(Posts);
          
         
        }
        public IActionResult Previous()
        {
          CurrentPage--;
          return Redirect("/Blog/Index");
        }
        public IActionResult Next()
        {
          CurrentPage++;
          return Redirect("/Blog/Index");
        }
        
        [AuthorizationFilter()]
        public IActionResult CreatePost(int id) //Loads an empty form. If a BlogPost.Id is passed, the according Data is loaded in Order to edit the Post.
        {
          var Post = repository.BlogPosts.ById(id);
          if (Post!= null)
            return View(Post);
          return View(new BlogPost());
        }
        
        [AuthorizationFilter()]
        public IActionResult DeletePost(int id)
        {
          if(id!=0)
            repository.BlogPosts.Delete(id);
          return Redirect("/Blog/Index");
        }        

        [AuthorizationFilter()]
        public IActionResult Post(int id, string Titel, string Content, string ImgLink) 
        {  
          if(id!=0) // If a Post is Edited the Original Post is loaded and the Data replaced by the new Content/Title
          {
            var OriginalPost= repository.BlogPosts.ById(id);
            OriginalPost.Titel= Titel;
            OriginalPost.Content= Content;
            if(ImgLink!= null)
              OriginalPost.ImgLink=ImgLink;
            repository.BlogPosts.Save(OriginalPost);
            return Redirect("/Blog/Index");
          }
          //If no such Original Post exists, a new one is created from the form's data and saved
          User Author = repository.Users.ById((int)HttpContext.Session.GetInt32("user_ID"));
          BlogPost post= new BlogPost(Author.firstname, Author.lastname, Titel, Content);
          if (ImgLink!= null)
            post.ImgLink=ImgLink;
          else 
            post.ImgLink= "https://redzonekickboxing.com/wp-content/uploads/2017/04/default-image-620x600.jpg";
          repository.BlogPosts.Save
          (
            post
          );  
          logger.LogInformation("new blog created by" + Author.lastname);      
          return Redirect("/Blog/Index");
        }
        

    }
}

