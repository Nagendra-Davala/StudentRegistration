using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Filters;
using StudentRegistration.Models;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using OfficeOpenXml;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {

        private  IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
           _studentRepository = studentRepository;
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
        [HttpsOnly]
        [HttpPost]
        public IActionResult StudentForm(StudentModel student)
        {
            if (ModelState.IsValid)
            {
              //  HttpContext.Session.SetString("First_Name",student.FName);
              //  StudentModel newStudent =
                    _studentRepository.Add(student);
                // return RedirectToAction("GetStudent", new { id = newStudent.Id });
                return RedirectToAction("GetAllStudents");
            }

            return View();
        }
        public IActionResult Details(int id)
        {
            StudentModel student1 = _studentRepository.GetStudent(id);
            return View("Details", student1);
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
           
        public IActionResult GetAllStudents()
        {
            var data = _studentRepository.GetAllStudents();
            return View(data);
        }
        public IActionResult Delete(int Id)
        {
            var data = _studentRepository.Delete(Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(StudentModel studentModel)
        {
            var data = _studentRepository.DeleteConfirm(studentModel);
            //  return View("GetAllStudents");
            return RedirectToAction("GetAllStudents");
        }
        [HttpPost]
        public IActionResult Search(IFormCollection form)
        {
            string email =form["email"];
            string name = form["fname"];
            string company = form["company"];
           
            if(string.IsNullOrEmpty(email) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(company))
            {
                GetAllStudents();
            }
           
              var data =  _studentRepository.Search(name,email,company);
                return View("GetAllStudents", data);
          
        }
        [HttpPost]
        public IActionResult Update(int Id,StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                var data = _studentRepository.Update(Id, studentModel);
                return View("Index");
            }
            return RedirectToAction("GetStudent", new { id = Id });
        }
        public IActionResult CSV()
        {
            var builder = new StringBuilder();
            builder.AppendLine("FirstName,MiddleName,LastName,Month,Gender,Day,Year,StreetAddress,StreetAddress2,Email,PhoneNumber,MobileNumber,WorkNumber,State,City,ZipCode,Company,Courses,Comments");
            // var data = _context.Students.ToList<StudentModel>();
            var data = _studentRepository.GetAllStudents();
            foreach (StudentModel student in data)
            {
                builder.AppendLine($"{student.FName},{student.MName},{student.LName},{student.Month},{student.Gender},{student.Day},{student.Year},{student.StreetAddress},{student.StreetAddress1},{student.City},");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Student.csv");
        }

        public IActionResult Excel()
        {
            using(var workbook = new XLWorkbook() )
            {
                var worksheet = workbook.Worksheets.Add("Students");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "FName";
                var data = _studentRepository.GetAllStudents();
                foreach(StudentModel student in data)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = student.FName;

                }
                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spredsheetxml.sheet",
                        "Student.xlsx");
                }
            }
        }
       


    }
}
