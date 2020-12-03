using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcCrud.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required (ErrorMessage ="Required")]
        public string fname{ get; set; }
        
        [Required(ErrorMessage = "Required")]
        public string lname { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Required")]
        public string mobile { get; set; }
        public string description { get; set; }
        [Display (Name="Department")]
        public int deptid { get; set; }
        [NotMapped]
        public string department { get; set; }
    }
}
