using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcCrud.Models
{
    public class Departments
    {
        [Key]
        public int deptid { get; set; }
        public string department { get; set; }
    }
}
