namespace MontiniInk.Model
{
    public class MemoryRepository : IRepository
    {
        MemoryRequestRepository RequestRepository;
        MemoryUserRepository UserRepository;
        MemoryBlogPostRepository BlogPostRepository;

        public MemoryRepository()
        {
            UserRepository = new MemoryUserRepository();
            BlogPostRepository = new MemoryBlogPostRepository();
            RequestRepository = new MemoryRequestRepository(); 

        }
        public IUserRepository Users 
        {
            get
            {
                return UserRepository;
            }
        }

        public IRequestRepository Requests 
        {
            get
            {
                return RequestRepository;
            }
        }

        public IBlogPostRepository BlogPosts 
        {
            get
            {
                return BlogPostRepository;
            }
        }
    }
}