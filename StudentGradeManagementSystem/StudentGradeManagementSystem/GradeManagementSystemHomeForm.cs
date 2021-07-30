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

namespace StudentGradeManagementSystem
{
    // connection string
    // const string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";

    // connection instance
    // this.conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);


    public partial class GradeManagementSystem : Form
    {
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
            new SearchResultForm().Show();
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
                default:
                    break;
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

            // move to 1.4
            calculateGPA(recordData.studentId);

        }
        public void calculateGPA(int id)
        {

        }
    }
    public class RecordData
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public string coursePrefix { get; set; }
        public string courseNumber { get; set; }
        public string grade { get; set; }
        public int year { get; set; }
        public string semester { get; set; }
    }

}
