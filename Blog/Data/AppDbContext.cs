using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.ViewModels;
using Blog.Models.Comments;

namespace Blog.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComments> SubComments { get; set; }

        // public DbSet<LoginViewModel> LoginViewModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasMany<Category>(c => c.categories)
                 .WithOne(p => p.post).HasForeignKey(s => s.postID); // s eshte per category,Id tek Category eshte celes i jashtem i id se postimit


        }
    }
}
