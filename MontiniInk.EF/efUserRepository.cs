using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MontiniInk.Model;
using SimpleHashing.Net;

namespace MontiniInk.EF

{
    public class efUserRepository : IUserRepository
    {
        private MontiniInkContext context;
        private SimpleHash encryption{get;}

        public efUserRepository(MontiniInkContext context)
        {
            this.context = context;
            encryption = new SimpleHash();
            if(All().Count==0)
            {
                User Admin= new User("Admin", "Admin", "Admin@MontiniInk.de", "veryunsafepassword");
                Save(Admin);
            }
                
        }
        

        
        public List<User> All(int from = 0, int max = 1000)
        {
            return context.Users.Skip(from).Take(max).ToList();
        }

        public User ById(int id)
        {
            return (from obj in context.Users where obj.ID == id select obj).SingleOrDefault();
        }

        public void Delete(int id)
        {
            var obj = ById(id);
            context.Users.Attach(obj);
            context.Entry(obj).State= Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }

        public User findbyEmail(string Email)
        {
            return (from obj in context.Users where obj.Email.Equals(Email) select obj).SingleOrDefault();
            
        } 

        public User findbyEmailandPassword(LoginModel login)
        {
            var list= (from obj in context.Users where obj.Email.Equals(login.Email) select obj).ToList();
            foreach(var obj in list)
            {
                if (encryption.Verify(login.Passwort, obj.Password))
                    return obj;
            }
            return null;
        }

        public void Save(User obj)
        {
            if(obj.isAdmin)
                obj.Password = encryption.Compute(obj.Password);
            context.Add(obj);
            context.SaveChanges();
        }
    }
}