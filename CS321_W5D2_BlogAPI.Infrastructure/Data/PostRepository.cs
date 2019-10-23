using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dBContext;
        public PostRepository(AppDbContext dbContext) 
        {
            _dBContext = dbContext;
        }

        public Post Get(int id)
        {
            return _dBContext.Posts.Include(p => p.Blog)
                .ThenInclude(p => p.User)
                .FirstOrDefault(p => p.Id == id);

            // TODO: Implement Get(id). Include related Blog and Blog.User
            //throw new NotImplementedException();
        }

        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _dBContext.Posts
                .Include(p => p.Blog)
                .ThenInclude(b => b.User)
            .Where(p => p.BlogId == blogId);//UNSURE
            // TODO: Implement GetBlogPosts, return all posts for given blog id
            // TODO: Include related Blog and AppUser
            //throw new NotImplementedException();

        }

        public Post Add(Post post) // made small
        {

            _dBContext.Posts.Add(post);
            _dBContext.SaveChanges();
            return post;

            // : add Post
           // throw new NotImplementedException();
        }

        public Post Update(Post updatedPost)
        {
            var CurrentPost = this.Get(updatedPost.Id);
         
            if (CurrentPost == null) return null;

            _dBContext.Entry(CurrentPost)
               .CurrentValues
               .SetValues(updatedPost);
            _dBContext.Posts.Update(CurrentPost);
            _dBContext.SaveChanges();
                return CurrentPost;
            

            //  update Post
            // throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            //  get all posts
            // throw new NotImplementedException();
            return _dBContext.Posts.Include(p => p.Blog)
                 .ThenInclude(b => b.User);
        }

        public void Remove(int id)
        {
            //  remove Post
            //throw new NotImplementedException();
            var currentPost = this.Get(id);
            if (currentPost !=null)
            {
                _dBContext.Posts.Remove(currentPost);
                _dBContext.SaveChanges();
            }
        }

    }
}
