using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDotNetCoreCrudNew.Interfaces;
using WebAppDotNetCoreCrudNew.Models;

namespace WebAppDotNetCoreCrudNew.Repositry
{
    public class EmpolyeeRepo : IEmpolyee
    {
        private readonly StudentContext context;

        public EmpolyeeRepo(StudentContext _context)
        {
            context = _context;
        }
        public Student Getdetail(int id)
        {
            return context.tbl_Studentses.Find(id);
        }

        public IEnumerable<Student> Getdetails()
        {
            return context.tbl_Studentses;
        }
    }
}
