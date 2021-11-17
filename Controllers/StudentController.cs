using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;
using WebApplicationApi.StudentData;

namespace WebApplicationApi.Controllers
{ 
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentData _StudentData;

        public StudentController(IStudentData studentData)
        {
            _StudentData = studentData;
        }


        [HttpGet]
        [Route("{api}/{controller}")]
        public IActionResult GETStudents()
        {
            return Ok(_StudentData.GetStudents());
        }
        [HttpGet]
        [Route("api/[controller]/{action}/{id}")]
        public IActionResult  GetStudent( int id )
        {
            var student = _StudentData.GetStudent(id);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound($"student with  id : {id } was not found");
           
        }
        [HttpPost]
        [Route("api/[Controller]")]
        public IActionResult GetStudent(Student student)
        {
            _StudentData.AddStudent(student);
            return Created(HttpContext.Request.Scheme + "//" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + student.Id, student);

        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            var existingStudent = _StudentData.GetStudent(id);
            if(existingStudent != null)
            {
                student.Id = existingStudent.Id;
                _StudentData.EdditStudent(student);
            }
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var Student = _StudentData.GetStudent(id);
            if (Student != null)
            {
                _StudentData.DeleteStudent(Student);
                return Ok();
            }
            return NotFound($"Student with id : {id} was not found");

        }
    }
}
