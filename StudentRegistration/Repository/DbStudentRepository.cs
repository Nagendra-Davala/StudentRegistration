//using GemBox.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Repository
{
    public class DbStudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        public DbStudentRepository(StudentDbContext context)
        {
            _context = context;
        }
        public StudentModel Add(StudentModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public StudentModel Delete(int id)
        {
            var data = _context.Students.Where(s => s.Id == id).FirstOrDefault();
            //_context.Students.Remove(data);
            //_context.SaveChanges();
            return data;

        }
        [HttpPost]
        public StudentModel DeleteConfirm(StudentModel student)
        {
            // var data = _context.Students.Where(s => s.Email == Email).FirstOrDefault();
            _context.Students.Remove(student);//.State = EntityState.Deleted;
            _context.SaveChanges();
            return student;

        }

        public StudentModel Update(int Id,StudentModel studentModel)
        {

            //    _context.Students.Find(Id).Email = studentModel.Email;
            //_context.Students.Find(Id).PhoneNumber = studentModel.PhoneNumber;
          //  _context.Students.Attach(studentModel).Entity.Equals(Id);
             _context.Students.Attach(studentModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var data = _context.Students.Find(Id);
           _context.SaveChanges();
            return data;
                
        }

        public List<StudentModel> GetAllStudents()
        {
            var data = _context.Students.ToList();
            
            return data;
        }

        public StudentModel GetStudent(int? Id)
        {
          //  var data = _context.Students.Where(s => s.Id == Id).FirstOrDefault();
           var data = _context.Students.Find(Id ?? 1);
            return data;
        }

      
    }
}
