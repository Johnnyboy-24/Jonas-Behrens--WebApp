using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MontiniInk.Model;

namespace MontiniInk.EF

{
    public class efBlogPostRepository : IBlogPostRepository
    {
        private MontiniInkContext context;
        public BlogPost defaultPost;

        public efBlogPostRepository(MontiniInkContext context)
        {
            this.context= context;
            defaultPost= new BlogPost("Max", "Mustermann", "Das ist ein Titel", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.", "https://redzonekickboxing.com/wp-content/uploads/2017/04/default-image-620x600.jpg");
        }

        public List<BlogPost> All(int from = 0, int max = 1000)
        {
            return context.Posts.Skip(from).Take(max).ToList();
        }

        public BlogPost ById(int id)
        {
            return (from obj in context.Posts where obj.ID.Equals(id) select obj).SingleOrDefault();
        }

        public void Delete(int id)
        {
            var obj = ById(id);
            context.Posts.Attach(obj);
            context.Entry(obj).State= Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }

        public List<BlogPost> Latest(int Page)
        {
            Page--;
            Page= Page*3;
            var count = All().Count;
            var result = new List<BlogPost>();
            for (int i=1; i<=3; i++)
            {
                if((count-(i+Page))<0)
                    result.Add(defaultPost); 
                else 
                    result.Add(All()[count-(i+Page)]);
            } 
            return result;
        }

        public void Save(BlogPost obj)
        {
            if(obj.ID==0)
            {
                context.Add(obj);
                context.SaveChanges();
            }
            else
            {
                context.Posts.Attach(obj);
                context.Entry(obj).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}