using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {

        private  IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
           _studentRepository = studentRepository;
        }
        public IActionResult Sample()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult StudentForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentForm(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                StudentModel newStudent = _studentRepository.Add(student);
                 return RedirectToAction("GetStudent", new { id = newStudent.Id });
            }

            return View();
        }
        public IActionResult GetStudent(int id)
        {
            StudentModel student1 = _studentRepository.GetStudent(id);
            return View("StudentDetails", student1);
        }

        public IActionResult StudentDetails(StudentModel student)
        {
            return View(student);
        }
    }
}
