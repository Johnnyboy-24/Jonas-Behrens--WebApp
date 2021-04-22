using System.Collections.Generic;

namespace MontiniInk.Model
{
    public interface IBlogPostRepository 
    {
        List<BlogPost> All(int from=0,int max=1000);  
        List<BlogPost> Latest(int page);  
        BlogPost ById(int id);
        void Save(BlogPost obj);
        void Delete(int id);
    }
}
