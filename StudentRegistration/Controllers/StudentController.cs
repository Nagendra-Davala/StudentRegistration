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

        private readonly StudentRepository studentRepository;
        public StudentController()
        {
           studentRepository = new StudentRepository();
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
        //public IActionResult StudentForm(StudentModel student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        StudentModel newStudent = studentRepository.Add(student);
        //        return RedirectToAction("StudentDetails", new { student1 = newStudent });
        //    }

        //    return View();
        //}

        public IActionResult StudentDetails(StudentModel student)
        {

            if (ModelState.IsValid)
            {
                StudentModel newStudent = studentRepository.Add(student);
                return View(newStudent);
            }

            return View("StudentForm");

        }
    }
}
