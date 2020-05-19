using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class RegisterViewModel
    {   [Required(ErrorMessage = "Ju lutem vendosni adresen e email-it")]
   
        public string  Email { get; set; }
        [Required(ErrorMessage = "Ju lutem vendosni password-in")]

        [DataType(DataType.Password)]
        public string  Password { get; set; }
    }
}
