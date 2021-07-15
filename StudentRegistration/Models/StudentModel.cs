using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public enum MonthList { January, February, March, April, May, June, July, August, September, October, November, December }

    public enum GenderList { Male, Female, NA }
    public enum CoursesList { Windows8, IntroductionToLinux, English101, English102, CreativeWriting1, CreativeWriting2, History101, History102, Math101, Math102 }
    public class StudentModel
    {
        [Required(ErrorMessage ="First Name not be null..")]
       [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="First Name- Alphabets Only!..")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Middle Name not be null..")]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Middle Name -Alphabets Only!")]
        public string MName { get; set; }
        [Required(ErrorMessage = "Last Name-not null")]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name -Alphabets Only!")]
        public string LName { get; set; }  
        [Required(ErrorMessage ="Month - Required!")]
        public MonthList? Month { get; set; }
        [Required(ErrorMessage = "Gender - Required")]
        public GenderList? Gender { get; set; }
        [Required(ErrorMessage = "Day - Required!")]
        public int? Day { get; set; }
        [Required(ErrorMessage = "Year - Required!")]
        public int? Year { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress1 { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]+$", ErrorMessage = "Email format is wrong!")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[5-9][0-9]{9}$", ErrorMessage = "Number Contains 10 digits Only")]
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^[5-9][0-9]{9}$", ErrorMessage = "Number Contains 10 digits Only")]
        public string MobileNumber { get; set; }
        [RegularExpression(@"^[5-9][0-9]{9}$", ErrorMessage = "Number Contains 10 digits Only-Work")]
        public string WorkNumber { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "State/Province - Alphabets Only!")]
        public string State { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "City - Alphabets Only!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Zip Code - Required")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Only digits and lenght 6 chars")]
        public int? ZipCode { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Company - Alphabets Only")]
        public string Company { get; set; }
        [Required(ErrorMessage ="Courses required")]
        public CoursesList? Courses { get; set; }
        public string Comments { get; set; }
    }
}
