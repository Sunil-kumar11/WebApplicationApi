using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace WebApplicationApi.StudentData
{
   public interface IStudentData
    {

        List<Student> GetStudents();

        Student GetStudent(int Id);

        Student AddStudent(Student student);

        Student EdditStudent(Student student);

         void DeleteStudent(Student student);
    }
}
