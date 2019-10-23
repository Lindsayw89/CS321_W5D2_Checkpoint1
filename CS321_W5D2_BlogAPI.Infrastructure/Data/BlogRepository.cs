using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public BlogRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Blog> GetAll()
        {
            return _dbContext.Blogs
                .Include(b => b.User);

            //  Retrieve all blgs. Include Blog.User.
            //throw new NotImplementedException();
        }

        public Blog Get(int id)
        {
            return _dbContext.Blogs
                .Include(b => b.User)
                .FirstOrDefault(b => b.Id == id);
            //  Retrieve the blog by id. Include Blog.User.
           // throw new NotImplementedException();
        }

        public Blog Add(Blog blog)
        {
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();
            return blog;

            // Add new blog
            throw new NotImplementedException();
        }

        public Blog Update(Blog updatedBlog)
        {
            // update blog
            //throw new NotImplementedException();
            var existingBlog = _dbContext.Blogs.Find(updatedBlog.Id);
            if (existingBlog == null) return null;
            _dbContext.Entry(existingBlog)
               .CurrentValues
               .SetValues(updatedBlog);
            _dbContext.Blogs.Update(existingBlog);
            _dbContext.SaveChanges();
            return existingBlog;
        }

        public void Remove(int id)
        {

          //  _dbContext.Blogs.Remove(blog);
          //  _dbContext.SaveChanges();

            var currentBlog = this.Get(id);
            if (currentBlog !=null)
            {
               _dbContext.Blogs.Remove(currentBlog);
                _dbContext.SaveChanges();
            }
            //else
            //{
            //    throw new Exception("The blog enterd to be removed, does not exist");
           // }
            
            //  remove blog
            throw new NotImplementedException();
        }
    }
}
