using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLife.Models
{
    public class Students

    { 
        [Display(Name = "Class")]
        public int Class { get; set; }
        [Display(Name = "RollNo")]
        public int RollNo { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Age")]
        public int? Age { get; set; }


    }
}