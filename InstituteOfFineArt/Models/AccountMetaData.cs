using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Models
{
    public class AccountMetaData
    {
        [MinLength(3)]
        [MaxLength(10)]
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Pass { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]

        public string Fullname { get; set; }
        [Required]
        [EmailAddress] // phải có  .......@.........
        public string Email { get; set; }
    }
    [ModelMetadataType(typeof(AccountMetaData))]
    public partial class Account
    {

    }
}

