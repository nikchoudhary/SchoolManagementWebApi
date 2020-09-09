using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLifeClient.Models
{
    public class Attendance
    {
        [Display(Name = "RollNo")]
        public int RollNo { get; set; }

        [Display(Name = "Attendance1")]
        public string Attendance1 { get; set; }

        [Display(Name = "Result")]
        public double? Result { get; set; }
    }
}
