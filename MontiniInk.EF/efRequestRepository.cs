using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MontiniInk.Model;

namespace MontiniInk.EF

{
    public class efRequestRepository : IRequestRepository
    {
        private MontiniInkContext context;

        public efRequestRepository (MontiniInkContext context)
        {
            this.context= context;
        }

        public List<Request> All(int from = 0, int max = 1000)
        {
            return context.Requests.Skip(from).Take(max).ToList();
        }

        public Request ByDate(DateTime Date)
        {
            var list = All();
            foreach(var obj in list)
            {
                if(obj.Appointment.Date == Date.Date)
                return obj;
            }
            return null;
        }

        public Request ById(int id)
        {
            return (from obj in context.Requests where obj.ID.Equals(id) select obj).SingleOrDefault();
        }

        public void Delete(int id)
        {
            var obj = ById(id);
            context.Requests.Attach(obj);
            context.Entry(obj).State= Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }

        public List<Request> Latest()
        {
            var count = All().Count;
            var result = new List<Request>();
            for (int i=1; i<=3; i++)
            {
                result.Add(All()[count-i]);
            } 
            return result;
        }

        public void Save(Request obj)
        {
            if(obj.ID==0)
            {
                context.Add(obj);
                context.SaveChanges();
            }
            else
            {
                context.Requests.Attach(obj);
                context.Entry(obj).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();                
            }

        }
    }
}
