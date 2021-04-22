
namespace MontiniInk.Model
{
    public interface IRepository 
    {
        IUserRepository Users { get;  }
        IRequestRepository Requests {get; }
        IBlogPostRepository BlogPosts {get;}
    
    }
}
