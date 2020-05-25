using Blog.Models.Comments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
     

     
        public string Title { get; set; } =  " ";


        public string Body { get; set; } = " ";
  
        public string Image { get; set; } = " ";
      
       
        
        public ICollection<Category> categories { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public List<MainComment> MainComments { get; set; }
    }
}
