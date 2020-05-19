using Blog.Data.FileManager;
using Blog.Data.Repository;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Authorize (Roles="Admin")]
    public class PanelController : Controller
    {
        private IRepository repository;
        private IFileManager filemanager;
     
        
            public PanelController(IRepository r,IFileManager f)
        {
            repository = r;
            filemanager = f;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var posts = repository.getAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        { 
            if (id == null)
            {
               
            return View(new PostViewModel());  //kthen nje faqe bosh
            }
            else
            {
                var post = repository.getPost((int)id);
                return View(new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body
   
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit( PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var postim = new Post
                {
                    Id = post.Id,
                    Image = await filemanager.SaveImage(post.Image),
                    Title = post.Title,
                    Body = post.Body


                };
                if (postim.Id > 0)
                {
                    repository.UpdatePost(postim);
                }
                else
                {
                    repository.AddPost(postim);
                }
                if (await repository.SaveChangesAsync())
                {
                    return RedirectToAction("Index");

                }
            }
           
                return View(post);
            }


        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            repository.RemovePost(id);
            await repository.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}