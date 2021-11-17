using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace WebApplicationApi.StudentData
{
    public class MockStudentData : IStudentData
    {

        private List<Student> Students = new List<Student>()
        {
            new Student(){ Id=121,Name ="ramesh" , Address="ameerpet" , Cource ="Dot Net" },
            new Student(){ Id=122,Name="suresh", Address="panjagutta",Cource="java"}
        };
        public Student AddStudent(Student student)
        {
            Students.Add(student);
            return student;
        }

        public void DeleteStudent(Student student)
        {
            Students.Remove(student);
        }

        public Student EdditStudent(Student student)
        {
            var existingStudent = GetStudent(student.Id);

            existingStudent.Id = student.Id;
            existingStudent.Name = student.Name;
            existingStudent.Address = student.Address;
            existingStudent.Cource = student.Cource;

            return existingStudent;
        }

        public Student GetStudent(int id)
        {
            return Students.SingleOrDefault(x => x.Id == id);
        }

        public List<Student> GetStudents()
        {
            return Students;
        }
    }
}
