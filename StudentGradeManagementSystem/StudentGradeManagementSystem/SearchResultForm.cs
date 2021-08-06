using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentGradeManagementSystem.Models;

namespace StudentGradeManagementSystem
{
    public partial class SearchResultForm : Form
    {
        public List<GradeResult> results;
        public GradeManagementSystem parent;
        public RecordData selection;

        public event EventHandler OptionButtonPress;
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

            // set the data source
            this.SearchResultsListBox.DataSource = this.results;

            // pass the dynamic string property from the class
            this.SearchResultsListBox.DisplayMember = "getEntireInfo";

        }

        public SearchResultForm(GradeManagementSystem parent, List<CompleteGradeRecord> completeGradeRecords)
        {
            InitializeComponent();
            this.results = this.createGradeResultList(completeGradeRecords);
            this.parent = parent;

            // set the data source
            this.SearchResultsListBox.DataSource = this.results;
            this.SearchResultsListBox.DisplayMember = "getEntireInfo";
        }

        private void SearchResultsDeleteButton_Click(object sender, EventArgs e)
        {
            new DynamicConfirmationForm("Are you sure you wish to delete? Warning: Deletion is permanent.").Show();
        }
        private List<GradeResult> createGradeResultList(List<CompleteGradeRecord> completeGradeRecords)
        {

            // convert each CompleteGradeRecord to a GradeResult object
            List<GradeResult> results = new List<GradeResult>();
            foreach(CompleteGradeRecord record in completeGradeRecords)
            {
                GradeResult res = new GradeResult();
                res.Name = record.studentName;
                res.ID = record.studentId.ToString();
                res.Semester = record.semester;
                res.Year = record.year.ToString();
                res.CoursePrefix = record.coursePrefix;
                res.CourseNumber = record.coursePrefix;
                res.Grade = record.grade;
                results.Add(res);
            }

            // return the list
            return results;

        }

        private void SearchResultsEditButton_Click(object sender, EventArgs e)
        {
            this.selection = this.SearchResultsListBox.SelectedItem as RecordData;
            this.parent.myMain(3);
        }
    }

    // define the grade result class for the display of search results
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
