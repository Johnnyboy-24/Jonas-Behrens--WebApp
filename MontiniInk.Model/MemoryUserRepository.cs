using System.Collections.Generic;
using SimpleHashing.Net;

namespace MontiniInk.Model
{
    public class MemoryUserRepository : IUserRepository
    {
        
        public MemoryUserRepository()
        {
            encryption= new SimpleHash();
             if(All().Count==0)
            {
                User Admin= new User("Admin", "Admin", "Admin@MontiniInk.de", "veryunsafepassword");
                Save(Admin);
            }
           
        }
        public List<User> objects = new List<User>();
        public List<User> All(int from = 0, int max = 1000)
        {
            return objects;
        }
        private int PosOf(int id)
        {
            for(int i=0; i<objects.Count; i++)
            {
                if(objects[i].ID==id)
                    return i;
            }
            return -1;
        }


        public User ById(int id)
        {
            foreach (var obj in objects)
            {
                if(obj.ID==id)
                return obj;
            }
            return null;
        }

        public int Count
        {
           get
           { 
               return objects.Count;
           }
        }

        public SimpleHash encryption {get;}

        public void Delete(int id)
        {
            var Pos= PosOf(id);
            if(Pos!=-1)
            objects.RemoveAt(PosOf(id));
            
        }

        public void Save(User obj)
        {
            if(obj.isAdmin)
            {
                obj.Password= encryption.Compute(obj.Password);
            }

            if(obj.ID==0)
            {
                obj.ID=Count+1;
                objects.Add(obj);
            }
            else
            {
                var Pos = PosOf(obj.ID);
                objects[Pos]=obj;
            }
        }

        

        public User findbyEmailandPassword(LoginModel login)
        {
            foreach(User u in objects){
                if ((encryption.Verify(login.Passwort, u.Password))&&(u.Email==login.Email)){
                    return u;
                }
                

            }
            return null;
        }

        public User findbyEmail(string Email)
        {
            foreach(User u in objects){
                if (Email== u.Email)
                return u;

            }
            return null;
        }
    }
}