using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public class StudentRepository /*IStudentRepository*/
    {
        private List<StudentModel> GetStudents;
        public StudentRepository()
        {
            GetStudents = new List<StudentModel>();         
        }
        public StudentModel Add(StudentModel student)
        {
            student.Id = 1;
            GetStudents.Add(student);
            return student;
        }
        public StudentModel GetStudent(int? Id)
        {
            
            return GetStudents.FirstOrDefault(e => e.Id == Id);
            
        }
    }
}
