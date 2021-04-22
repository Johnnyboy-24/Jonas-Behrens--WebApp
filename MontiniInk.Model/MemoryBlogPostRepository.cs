using System.Collections.Generic;

namespace MontiniInk.Model
{
    public class MemoryBlogPostRepository : IBlogPostRepository
    {
        private BlogPost DefaultPost;
        public MemoryBlogPostRepository()
        {
            DefaultPost= new BlogPost("Max", "Mustermann", "Das ist ein Titel", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.", "https://redzonekickboxing.com/wp-content/uploads/2017/04/default-image-620x600.jpg");
        }
        public List<BlogPost> objects = new List<BlogPost>();
        public List<BlogPost> All(int from = 0, int max = 1000)
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

       
        public BlogPost ById(int id)
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

        public void Delete(int id)
        {
            var Pos= PosOf(id);
            if(Pos!=-1)
            objects.RemoveAt(PosOf(id));
            
        }

        public void Save(BlogPost obj)
        {
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

        public List<BlogPost> Latest(int page)
        {
            page--;
            page= page*3;
            List<BlogPost> recent= new List<BlogPost>();
            for(int i= 3; i >=1; i--)
            {
                if((objects.Count-(i+page))>=0)
                    recent.Add(objects[objects.Count-(i+page)]);
                else 
                    recent.Add(DefaultPost);
            }
            return recent;
        }
    }
}