using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.ViewModels
{
    public class SigninViewModels
    {
            [Required]
            public string Username { get; set; }
            [Required]
            public string Password { get; set; }

        public string Email { get; set; }
    }
}
