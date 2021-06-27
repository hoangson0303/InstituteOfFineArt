using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Models
{
    public class RoleMetaData
    {



            [MinLength(3)]
            [MaxLength(10)]
            [Required]
            public string NameRole { get; set; }
        
        }
        [ModelMetadataType(typeof(RoleMetaData))]
        public partial class Role
    {

        }
    
}
