using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Data;
using Blog.Data.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


using System.IO;
using Blog.Data.FileManager;
using Blog.ViewModels;
using Blog.Models.Comments;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        private IFileManager file;
        public HomeController(IRepository r,IFileManager f)
        {
            repository = r;
            file = f;
        }
       

        [HttpGet]
        public ActionResult <PostViewModel> Index(string search)
        {
      PostViewModel  posts = repository.GetAllPosts(search);
            return View(posts);
        }
        public IActionResult Post (int id)
        {
            var post = repository.getPost(id);
            return View(post);
        }
[HttpPost]
        public async Task<IActionResult> Comment (CommentViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Post", new { id = vm.PostId });
            }
            
            var post = repository.getPost(vm.PostId);
            //Nqs nuk ka nje koment kryesor
            if(vm.MainCommentId ==0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();
                post.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    Created = DateTime.Now,
                });
                repository.UpdatePost(post);
            }
            else
            { //Perndryshe,nqs ka koment kryesor shtohen komentet dytesore
                var comment = new SubComments
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    Created = DateTime.Now,
                } ;

                repository.AddSubComment(comment);
            }
            await repository.SaveChangesAsync();
            return RedirectToAction("Post", new { id = vm.PostId });
        }
            
            




    }
}
