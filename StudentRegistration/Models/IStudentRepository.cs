using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public interface IStudentRepository
    {
        StudentModel Add(StudentModel student);
        StudentModel GetStudent(int? Id);
        List<StudentModel> GetAllStudents();
        StudentModel Delete(string Email);
        StudentModel Update(int Id,StudentModel studentModel);
     
    }
}
