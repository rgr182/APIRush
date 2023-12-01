using Microsoft.AspNetCore.Mvc;
using Rush_2.Repositories;
using Rush_2.Entities;

namespace Rush_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        StudentRepository Student;

        public StudentController() {
            Student = new StudentRepository();
        }


        [HttpPost(Name = "SaveAlumno")]
        public string SaveAlumno(Student student )
        {
            Student.InsertStudent(student);
            return "Alumno";
        }
    } 
}