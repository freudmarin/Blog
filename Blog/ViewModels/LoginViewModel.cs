using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class LoginViewModel

    {
        [Required(ErrorMessage = "Ju lutem vendosni username-in")]
    
        public string Username{ get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ju lutem vendosni username-in")]
        public string Password { get; set; }
    }

}
