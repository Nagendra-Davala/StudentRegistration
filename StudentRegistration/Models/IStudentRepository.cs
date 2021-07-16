using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public interface IStudentRepository
    {
        StudentModel Add(StudentModel student);
        StudentModel GetStudent(int Id);
    }
}
