using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDotNetCoreCrudNew.Models;

namespace WebAppDotNetCoreCrudNew.Interfaces
{
    public interface IEmpolyee
    {
        Student Getdetail(int id);
        IEnumerable<Student> Getdetails();
    }
}
