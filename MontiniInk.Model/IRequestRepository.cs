using System;
using System.Collections.Generic;

namespace MontiniInk.Model
{
    public interface IRequestRepository 
    {
        
        List<Request> All(int from=0,int max=1000);  
        List<Request> Latest();  
        Request ById(int id);
        void Save(Request obj);
        void Delete(int id);

        Request ByDate(DateTime Date);
    }
}
