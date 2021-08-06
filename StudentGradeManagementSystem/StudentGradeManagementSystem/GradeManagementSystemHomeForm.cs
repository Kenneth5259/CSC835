using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StudentGradeManagementSystem.Models;

namespace StudentGradeManagementSystem
{
    // connection string
    // const string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";

    // connection instance
    // this.conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);


    public partial class GradeManagementSystem : Form
    {
        public SearchResultForm searchResultForm;
        public GradeManagementSystem()
        {
            InitializeComponent();
           // new DynamicMessageForm("The import was successful.Total Courses Imported: 1, Total grades addes: 30").Show();
        }

        private void MainMenuAddButton_Click(object sender, EventArgs e)
        {
            this.AddGradeTableLayoutPanel.Visible = true;
        }

        private void AddGradeFormSubmitButton_Click(object sender, EventArgs e)
        {
            this.AddGradeTableLayoutPanel.Visible = false;
            this.myMain(1);
            //new DynamicMessageForm("").Show();
            
        }

        private void SearchGradeSubmitButton_Click(object sender, EventArgs e)
        {
            this.SearchGradeFormTableLayoutPanel.Visible = false;
            //new DynamicMessageForm("Edit Successful").Show();
            this.myMain(2);
        }

        private void MainMenuSearchButton_Click(object sender, EventArgs e)
        {
            this.SearchGradeFormTableLayoutPanel.Visible = true;
            this.SearchGradeSubmitButton.Enabled = true;
        }

        private void MainMenuPrintButton_Click(object sender, EventArgs e)
        {
            this.PrintStudentGradeReportTableLayoutPanel.Visible = true;
        }
        public void myMain(int x)
        {
            int input = x;
            switch(input)
            {
                // indicates that the GradeFormSubmitButton has been pressed
                case 1:
                    readGradeInformation();
                    break;
                case 2:
                    readSearchOptions();
                    break;
                case 3:
                    editAGrade(this.searchResultForm.selection);
                    break;
                case 4:
                    deleteAGrade(this.searchResultForm.selection);
                    break;
                default:
                    break;
            }
        }
        // DFD 2.1
        public void readSearchOptions()
        {
            
            // create an object for holding the search data
            RecordData searchData = new RecordData();

            // receive the input from the form
            searchData.studentId = Int32.Parse(this.SearchGradeStudentIDInput.Text);
            searchData.studentName = this.SearchGradeStudentNameInput.Text;
            searchData.courseNumber = this.SearchGradeCourseNumberInput.Text;
            searchData.coursePrefix = this.SearchGradeCoursePrefixInput.Text;
            searchData.grade = this.SearchGradeCourseGradeInput.Text;
            searchData.semester = this.SearchGradeSemesterInput.Text;
            searchData.year = Int32.Parse(this.SearchGradeYearInput.Text);

            // DFD 2.2
            searchGradeRecords(searchData);
        }

        //DFD 2.2
        public void searchGradeRecords(RecordData searchData)
        {
            List<CompleteGradeRecord> completeGradeRecords = new List<CompleteGradeRecord>();
            // grab the connection string
            const string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;SslMode=None";

            // create a connection instance
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            // student grades table
            DataTable studentGrades = new DataTable();

            // string for appending
            string table = "carroll_student_grades";
            string queryConditions = "";
            bool appendAnd = false;

            // conditiional search parameters
            if(searchData.studentName != "")
            {
                queryConditions += $"{table}.Name={searchData.studentName}";
                appendAnd = true;
            }
            if(searchData.studentId != 0 )
            {
                queryConditions += appendAnd ? " AND " : "";
                queryConditions += $"{table}.StudentID={searchData.studentId}";
                appendAnd = true;
            }
            if(searchData.coursePrefix != "")
            {
                queryConditions += appendAnd ? " AND " : "";
                queryConditions += $"{table}.CoursePrefix={searchData.coursePrefix}";
                appendAnd = true;
            }
            if (searchData.courseNumber != "")
            {
                queryConditions += appendAnd ? " AND " : "";
                queryConditions += $"{table}.CourseNumber={searchData.courseNumber}";
                appendAnd = true;
            }
            if (searchData.grade != "")
            {
                queryConditions += appendAnd ? " AND " : "";
                queryConditions += $"{table}.Grade={searchData.grade}";
                appendAnd = true;
            }
            if (searchData.semester != "")
            {
                queryConditions += appendAnd ? " AND " : "";
                queryConditions += $"{table}.Semester={searchData.semester}";
                appendAnd = true;
            }
            if (searchData.year > 0)
            {
                queryConditions += appendAnd ? " AND " : "";
                queryConditions += $"{table}.Year={searchData.year}";
            }

            try
            {

                // open the connection
                conn.Open();

                // create the sql statement
                string sql = "SELECT * FROM carroll_student_grades INNER JOIN carroll_course_credit_hours ON carroll_student_grades.CourseID = carroll_course_credit_hours.CourseID INNER JOIN carroll_student_info ON carroll_student_grades.StudentID = carroll_student_info.StudentID WHERE " + queryConditions + ";";

                // declare a new command
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                // execute the command
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);

                // fill the table
                myAdapter.Fill(studentGrades);

                // iterate over each row of the table (the string passed ot grade is determined by the columns created by the SQL statement)
                foreach (DataRow grade in studentGrades.Rows)
                {
                    // create a new grade record instance ( refer to data dictionary )
                    CompleteGradeRecord record = new CompleteGradeRecord();
                    record.courseNumber = grade["CourseNumber"].ToString();
                    record.courseNumber = grade["CoursePrefix"].ToString();
                    record.year = Int32.Parse(grade["Year"].ToString());
                    record.studentId = Int32.Parse(grade["StudentID"].ToString());
                    record.grade = grade["Grade"].ToString();
                    record.semester = grade["Semester"].ToString();
                    record.creditHours = Int32.Parse(grade["Hours"].ToString());
                    record.courseID = Int32.Parse(grade["CourseID"].ToString());
                    record.studentName = grade["Name"].ToString();

                    // push to the list to be returned
                    completeGradeRecords.Add(record);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close the connection
            conn.Close();

            // DFD 2.3
            verifyAmoundOfRecords(completeGradeRecords);
        }

        // DFD 2.3
        public void verifyAmoundOfRecords(List<CompleteGradeRecord> completeGradeRecords)
        {
            if(completeGradeRecords.Count > 0)
            {
                this.searchResultForm = new SearchResultForm(this, completeGradeRecords);
                this.searchResultForm.Show();
            } else
            {
                new DynamicMessageForm("Nothing found for the search parameters!").Show();
            }
        }

        // DFD 1.1
        public void readGradeInformation()
        {
            // create a new record data instance
            RecordData recordData = new RecordData();

            // receive the input from the form
            recordData.studentId = Int32.Parse(this.AddGradeIDInput.Text);
            recordData.studentName = this.AddGradeNameInput.Text;
            recordData.coursePrefix = this.AddGradeCoursePrefixInput.Text;
            recordData.courseNumber = this.AddGradeCourseNumberInput.Text;
            recordData.grade = this.AddGradeGradeInput.Text;
            recordData.semester = this.AddGradeSemesterInput.Text;
            recordData.year = Int32.Parse(this.AddGradeYearInput.Text);

            // validate the record data
            this.verifyGradeRecord(recordData);
        }

        // DFD 1.2.1
        public void verifyGradeRecord(RecordData recordData)
        {
            // record does not exist and can be added
            if(!retrieveGradeRecord(recordData))
            {
                // add grade record
                addGradeRecord(recordData);

            // record exists and cannot be added
            } else
            {
                new DynamicMessageForm("Record Already Exists!").Show();
            }
        }

        // DFD 1.2.2
        public bool retrieveGradeRecord(RecordData recordData)
        {
            // grab the connection string
            const string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;SslMode=None";
            // create a connection instance
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try {
               
                // open the connection
                conn.Open();

                // create the sql statement
                const string sql = "SELECT * FROM carroll_student_grades WHERE StudentID=@id AND CoursePrefix=@prefix AND CourseNum=@num AND Year=@year AND Semester=@semester";

                // declare a new command
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                // insert data values
                cmd.Parameters.AddWithValue("@id", recordData.studentId);
                cmd.Parameters.AddWithValue("@prefix", recordData.coursePrefix);
                cmd.Parameters.AddWithValue("@num", recordData.courseNumber);
                cmd.Parameters.AddWithValue("@year", recordData.year);
                cmd.Parameters.AddWithValue("@semester", recordData.semester);

                // create a reader for the command
                MySqlDataReader myreader = cmd.ExecuteReader();

                return myreader.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return true;
            }
            conn.Close();
            
        }
        public void editAGrade(RecordData recordData)
        {

        }

        public void deleteAGrade(RecordData recordData)
        {

        }

        // DFD 1.3
        public void addGradeRecord(RecordData recordData)
        {
            // grab the connection string
            const string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;SslMode=None";
           
            // create a connection instance
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try {
                
                // open the connection
                conn.Open();

                // create the sql statement
                const string sql = "INSERT INTO carroll_student_grades (StudentID, CoursePrefix, CourseNum, Grade, Year, Semester) VALUES (@id, @prefix, @num, @grade, @year, @semester)";

                // declare a new command
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                // insert data values
                cmd.Parameters.AddWithValue("@id", recordData.studentId);
                cmd.Parameters.AddWithValue("@prefix", recordData.coursePrefix);
                cmd.Parameters.AddWithValue("@num", recordData.courseNumber);
                cmd.Parameters.AddWithValue("@grade", recordData.grade);
                cmd.Parameters.AddWithValue("@year", recordData.year);
                cmd.Parameters.AddWithValue("@semester", recordData.semester);

                // execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close the connection
            conn.Close();

            // move to 1.4.3
            float gpa = calculateGPA(recordData.studentId);

            // move to 1.4.4
            saveGPA(recordData.studentId, gpa);

        }

        public void saveGPA(int id, float GPA)
        {
            // grab the connection string
            const string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;SslMode=None";

            // create a connection instance
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                // open the connection
                conn.Open();

                // create the sql statement
                const string sql = "UPDATE carroll_student_info SET OverallGPA=@gpa WHERE StudentID=@id";

                // declare a new command
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                // insert data values
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@gpa", GPA);

                // execute the command
                cmd.ExecuteNonQuery();

                // close the connection
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return;
        }
        public float calculateGPA(int id)
        {

            // receive grade records (1.4.2)
            List<CompleteGradeRecord> completeGradeRecords = getGradesByStudentId(id);

            // initialize gpa
            float gpa = 0;

            // initialize number of hours taken
            float totalHours = 0;

            // list of tuples mapping grade to credit hour on a per course basis
            List<(float, float)> gradeContributionList = new List<(float, float)>();

            // iterate on the records
            foreach(CompleteGradeRecord record in completeGradeRecords)
            {
                // initialize a grade value
                float gradeValue = 0;

                // switch on the letter grade and assign value
                switch(record.grade)
                {
                    case "A":
                        gradeValue += 4;
                        break;
                    case "B":
                        gradeValue += 3;
                        break;
                    case "C":
                        gradeValue += 2;
                        break;
                    case "D":
                        gradeValue += 1;
                        break;
                    default:
                        gradeValue += 0;
                        break;
                }

                // add value and credit hour amount
                gradeContributionList.Add((gradeValue, record.creditHours));
                
                // add to total hour summation
                totalHours += record.creditHours;
            }

            // for each tuple, add to gpa
            foreach((float, float) grade in gradeContributionList)
            {

                // add to overall gpa (4 credit hour course is worth more than 3 hour course etc.
                gpa += grade.Item1 * grade.Item2 / totalHours;
            }

            // return the GPA
            return gpa;
        }

        public List<CompleteGradeRecord> getGradesByStudentId(int id)
        {
            List<CompleteGradeRecord> completeGradeRecords = new List<CompleteGradeRecord>();
            // grab the connection string
            const string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;SslMode=None";

            // create a connection instance
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            // student grades table
            DataTable studentGrades = new DataTable();

            try
            {

                // open the connection
                conn.Open();

                // create the sql statement
                const string sql = "SELECT * FROM carroll_student_grades INNER JOIN carroll_course_credit_hours ON carroll_student_grades.CourseID = carroll_course_credit_hours.CourseID INNER JOIN carroll_student_info ON carroll_student_grades.StudentID = carroll_student_info.StudentID WHERE carroll_student_grades.StudentID= @id";

                // declare a new command
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                // insert data values
                cmd.Parameters.AddWithValue("@id", id);

                // execute the command
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);

                // fill the table
                myAdapter.Fill(studentGrades);

                // iterate over each row of the table (the string passed ot grade is determined by the columns created by the SQL statement)
                foreach (DataRow grade in studentGrades.Rows)
                {
                    // create a new grade record instance ( refer to data dictionary )
                    CompleteGradeRecord record = new CompleteGradeRecord();
                    record.courseNumber = grade["CourseNumber"].ToString();
                    record.courseNumber = grade["CoursePrefix"].ToString();
                    record.year = Int32.Parse(grade["Year"].ToString());
                    record.studentId = Int32.Parse(grade["StudentID"].ToString());
                    record.grade = grade["Grade"].ToString();
                    record.semester = grade["Semester"].ToString();
                    record.creditHours = Int32.Parse(grade["Hours"].ToString());
                    record.courseID = Int32.Parse(grade["CourseID"].ToString());
                    record.studentName = grade["Name"].ToString();

                    // push to the list to be returned
                    completeGradeRecords.Add(record);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close the connection
            conn.Close();

            return completeGradeRecords;
        }
    }
    

}
