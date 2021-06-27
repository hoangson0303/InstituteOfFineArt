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
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [Display(Name = "DateStart Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [Display(Name = "DateEnd Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }
    }
    [ModelMetadataType(typeof(CompitionMetaData))]
    public partial class Competition
    {

    }
}
