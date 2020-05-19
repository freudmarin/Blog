using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Post post { get; set; }

        public int postID { get; set; }
    }
}
