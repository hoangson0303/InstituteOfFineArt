using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.ViewModels
{
    public class SiginViewModels
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public bool Rememberme { get; set; }
    }
}
