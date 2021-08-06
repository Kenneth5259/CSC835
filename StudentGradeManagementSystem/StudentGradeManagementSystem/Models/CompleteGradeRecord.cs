using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManagementSystem.Models
{
    public class CompleteGradeRecord 
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public string coursePrefix { get; set; }
        public string courseNumber { get; set; }
        public string grade { get; set; }
        public int year { get; set; }
        public string semester { get; set; }
        public int creditHours { get; set; }
        public int courseID { get; set; }
        public float overallGPA { get; set; }
    }
}
