using Blog.Models;
using Blog.Models.Comments;
using Blog.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class Repository :IRepository
    {
        private AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

       public Post getPost(int id)
        {
            return _db.Posts
                .Include(p => p.MainComments).ThenInclude(mc=>mc.SubComments).FirstOrDefault(c => c.Id == id);
        }
  
        public  List<Post> getAllPosts()
        {
            return _db.Posts.ToList();
        }

        public void AddPost(Post post)
        {
            _db.Posts.Add(post);


        }

        public void UpdatePost(Post post)
        {
            _db.Posts.Update(post);
        }

        public void RemovePost(int id)
        {
            _db.Posts.Remove(getPost(id));
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _db.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }

        public void AddSubComment(SubComments subcomment)
        {
            _db.SubComments
                  .Add(subcomment);
        }
        public void AddMainComment(MainComment maincomment)
        {
            _db.MainComments
                  .Add(maincomment);
        }

        PostViewModel IRepository.GetAllPosts(string search)
        {
            var query = _db.Posts.AsQueryable();
            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(x => (x.Body + x.Title).Contains(search));
            }
            return new PostViewModel
            {
                search = search,
                Posts = query.ToList(),

            };
        }
    }
}


