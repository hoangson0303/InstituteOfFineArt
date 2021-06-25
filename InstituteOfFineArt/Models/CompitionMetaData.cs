using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Models
{
    public class CompitionMetaData
    {
        
            [MinLength(3)]
            [MaxLength(10)]
            [Required]
            public string NameCom { get; set; }
          
           
        
       
    }
    [ModelMetadataType(typeof(CompitionMetaData))]
    public partial class Competition
    {

    }
}
