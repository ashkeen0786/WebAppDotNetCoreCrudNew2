using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDotNetCoreCrudNew.Interfaces;
using WebAppDotNetCoreCrudNew.Models;

namespace WebAppDotNetCoreCrudNew.Controllers
{
    public class StudentController : Controller
    {

        //private readonly IEmpolyee employee;
        //public StudentController(IEmpolyee _employee)
        //{
        //    employee = _employee;
        //}
        private readonly StudentContext _Db;
        public StudentController(StudentContext Db)
        {
            _Db = Db;
           
        }

        //public IActionResult getdetails()
        //{
        //    var data = employee.Getdetails();
        //    return View(data);
        //}

        public IActionResult StudentList()
        {
            try
            {
                //var stdList = _Db.tbl_Student.ToList();

                var stdList = from a in _Db.tbl_Studentses
                              join b in _Db.tbl_Departmente
                              on a.Dep_ID equals b.ID
                              into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Student
                              {
                                  ID = a.ID,
                                  Name = a.Name,

                                  Email = a.Email,
                                  emp_code = a.emp_code,
                                  //gender = a.gender,
                                  //last_name=a.last_name,
                                  //phonee=a.phonee,
                                 

                                  Dep_ID = a.Dep_ID,
                                  Department = b == null ? "" : b.Department

                              };


                return View(stdList);
            }
            catch (Exception ex)
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
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _Db.tbl_Studentses.Add(obj);
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



        public async Task<IActionResult> DeleteStd(int id)
        {
            try
            {
                var std = await _Db.tbl_Studentses.FindAsync(id);
                if (std != null)
                {
                    _Db.tbl_Studentses.Remove(std);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("StudentList");
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
                List<Departments> depList = new List<Departments>();
                depList = _Db.tbl_Departmente.ToList();

                depList.Insert(0, new Departments { ID = 0, Department = "Please Select" });

                ViewBag.DepList = depList;

            }
            catch (Exception ex)
            {


            }
        }
    }

}