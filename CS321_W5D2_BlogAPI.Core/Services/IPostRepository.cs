using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public interface IPostRepository
    {
        Post Add(Post post); // changed lower case p
        Post Update(Post post); // changed lower case p
        Post Get(int id);
        IEnumerable<Post> GetAll();
        void Remove(int id);
        IEnumerable<Post> GetBlogPosts(int blogId);
    }
}
