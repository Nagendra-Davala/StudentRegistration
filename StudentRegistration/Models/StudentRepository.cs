using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public class StudentRepository
    {
        private List<StudentModel> GetStudents;
        public StudentRepository()
        {
            GetStudents = new List<StudentModel>();         
        }
        public StudentModel Add(StudentModel student)
        {
            GetStudents.Add(student);
            return student;
        }
    }
}
