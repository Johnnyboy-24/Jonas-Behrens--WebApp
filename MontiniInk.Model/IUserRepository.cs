using System.Collections.Generic;
using SimpleHashing.Net;

namespace MontiniInk.Model
{
    public interface IUserRepository 
    {
        
        
        List<User> All(int from=0,int max=1000);   
        User ById(int id);
        void Save(User obj);
        void Delete(int id);
        User findbyEmailandPassword(LoginModel login);

        User findbyEmail(string Email);
    
    }
}
