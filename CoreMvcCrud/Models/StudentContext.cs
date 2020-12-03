using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcCrud.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>options):base(options)
        {

        }
        public DbSet<Student> tbl_student { get; set; }
        public DbSet<Departments> tbl_department { get; set; }
    }
}
