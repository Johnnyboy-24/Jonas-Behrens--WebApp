using System;
using Microsoft.EntityFrameworkCore;
using MontiniInk.Model;

namespace MontiniInk.EF

{
    public class efRepository : IRepository, IDisposable
    {
        private IUserRepository userRepository;
        private IRequestRepository requestRepository;
        private IBlogPostRepository blogPostRepository;
        private MontiniInkContext context;
        public efRepository()
        {
            context = new MontiniInkContext();
            userRepository= new efUserRepository(context);
            requestRepository= new efRequestRepository(context);
            blogPostRepository= new efBlogPostRepository(context);

        }
        public IUserRepository Users 
        {
            get
            {
                return userRepository;
            }
        }
        public IRequestRepository Requests 
        {
            get
            {
                return requestRepository;
            }
        }

        public IBlogPostRepository BlogPosts 
        {
            get
            {
                return blogPostRepository;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}