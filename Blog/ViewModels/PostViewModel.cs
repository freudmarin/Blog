using Blog.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Blog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string search { get; set; }
       [Required(ErrorMessage = "Ju lutem ngarkoni imazhin")]
        public IFormFile Image { get; set; } 

        [Required(ErrorMessage = "Ju lutem vendosni titullin e postimit")]
        public string Title { get; set; } 

        [Required(ErrorMessage = "Postimi nuk duhet te jete bosh")]
        public string Body { get; set; }
        public IEnumerable<Post> Posts { get; set; }

    }
}
