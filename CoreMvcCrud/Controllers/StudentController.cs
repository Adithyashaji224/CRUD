using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMvcCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcCrud.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _Db;

        public StudentController(StudentContext Db)
        {
            _Db = Db;
        }
        public IActionResult StudentList()
        {
            try
            {
                var studlist = from a in _Db.tbl_student
                               join b in _Db.tbl_department
                               on a.deptid equals b.deptid
                               into dep from b in dep.DefaultIfEmpty()

                               select new Student
                               {
                                   id = a.id,
                                   fname = a.fname,
                                   lname = a.lname,
                                   email = a.email,
                                   mobile = a.mobile,
                                   description = a.description,
                                   deptid = a.deptid,

                                   department = b == null ? "" : b.department

                             };
                return View(studlist);
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }

        public IActionResult Create(Student obj)
        {
            loadDDL();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(obj.id==0)
                    {
                        _Db.tbl_student.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                    return RedirectToAction("StudentList");
                }
                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("StudentList");
            }
            
        }

        private void loadDDL()
        {
            try
            {
                List<Departments> deplist = new List<Departments>();
                deplist = _Db.tbl_department.ToList();
                deplist.Insert(0, new Departments { deptid = 0, department = "Please enter" });
                ViewBag.Deplist = deplist;
            }
            catch (Exception ex)
            {

             
            }
        }

        public async Task<IActionResult> Deletestd(int id)
        {
            try
            {
                var std = await _Db.tbl_student.FindAsync(id);
                if(std!=null)
                {
                    _Db.tbl_student.Remove(std);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("StudentList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("StudentList");
            }
        }
    }
}