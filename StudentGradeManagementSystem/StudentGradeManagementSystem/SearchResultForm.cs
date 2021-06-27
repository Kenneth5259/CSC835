using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGradeManagementSystem
{
    public partial class SearchResultForm : Form
    {
        public List<GradeResult> results;
        public SearchResultForm()
        {
            InitializeComponent();
            this.results = new List<GradeResult>();
            GradeResult test = new GradeResult();
            test.Name = "Kenneth Carroll";
            test.ID = "0000001";
            test.Semester = "Summer";
            test.Year = "2021";
            test.CoursePrefix = "CSC";
            test.CourseNumber = "835";
            test.Grade = "B";
            this.results.Add(test);
            this.SearchResultsListBox.DataSource = this.results;
            this.SearchResultsListBox.DisplayMember = "getEntireInfo";

        }
    }
    public class GradeResult
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public string Semester { get; set; }

        public string Year { get; set; }
        public string CoursePrefix { get; set; }

        public string CourseNumber { get; set; }

        public string Grade { get; set; }
        public string getEntireInfo
        {
            get
            {
                return this.Name + " - " + this.ID + " - " + this.Semester + " " + this.Year + " - " + this.CoursePrefix + this.CourseNumber + " - " + this.Grade;
            }

        }
    }
}
