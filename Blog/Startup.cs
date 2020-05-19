using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Blog.Data.FileManager;

namespace Blog
{
    public class Startup
    {
        private IConfiguration Configuration;
 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.


        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
             {
                 options.Password.RequireDigit = false;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequiredLength = 3;
             })//.AddRoles<IdentityRole>()

            // .AddDefaultUI()
             .AddEntityFrameworkStores<AppDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
            });
            services.AddTransient<IFileManager, FileManager>();
            services.AddTransient<IRepository, Repository>();
         
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            // Set requirements for security
            /*     services.Configure<IdentityOptions>(options =>
                     {
                         options.Password.RequiredLength = 8;
                         options.Password.RequireUppercase = true;
                         options.Password.RequireLowercase = true;

                         // Default User settings.
                         options.User.AllowedUserNameCharacters =
                                 "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                         options.User.RequireUniqueEmail = true;

                     });



                     services.AddTransient<IRepository, Repository>();

         */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseRouting();


            app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                // Which is the same as the template
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}



