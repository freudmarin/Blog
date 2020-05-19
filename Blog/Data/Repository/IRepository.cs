using Blog.Models;
using Blog.Models.Comments;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public interface IRepository
    {
         PostViewModel GetAllPosts(string search);
         Post getPost(int id);
         List<Post> getAllPosts();
         void  AddPost(Post post);
          void UpdatePost(Post post);
        void AddMainComment(MainComment comment);
         void RemovePost(int id);
        Task<bool> SaveChangesAsync();
        void AddSubComment(SubComments subcomment);
        
    }
}
