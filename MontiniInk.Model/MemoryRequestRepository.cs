using System.Collections.Generic;
using System;

namespace MontiniInk.Model
{
    public class MemoryRequestRepository : IRequestRepository
    {
        public List<Request> Requests;

        public MemoryRequestRepository()
        {
            Requests= new List<Request>();
        }
        public int Count
        {
           get
           { 
               return Requests.Count;
           }
        }

        public List<Request> All(int from = 0, int max = 1000)
        {
            return Requests;
        }

        public Request ById(int id)
        {
            foreach (Request obj in Requests)
            {
                if(obj.ID==id)
                return obj;
            }
            return null;
        }

        private int PosOf(int id)
        {
            for(int i=0; i<Requests.Count; i++)
            {
                if(Requests[i].ID==id)
                    return i;
            }
            return -1;
        }

        public void Delete(int id)
        {
            var Pos= PosOf(id);
            if(Pos!=-1)
            Requests.RemoveAt(PosOf(id));
        }

        public List<Request> Latest()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Request obj)
        {
            if(obj.ID==0)
            {
                obj.ID=Count+1;
                Requests.Add(obj);
                
            }
            else
            {
                var Pos = PosOf(obj.ID);
                Requests[Pos]=obj;
            }
        }

        public Request ByDate(DateTime Date)
        {
            foreach(Request obj in Requests){
                if(obj.Appointment.Date == Date.Date)
                return obj;
            }
            return null;
        }
    }
}
