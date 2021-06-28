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
    public partial class GradeManagementSystem : Form
    {
        public GradeManagementSystem()
        {
            InitializeComponent();
            new DynamicMessageForm("The import was successful.Total Courses Imported: 1, Total grades addes: 30").Show();
        }

        private void MainMenuAddButton_Click(object sender, EventArgs e)
        {
            this.AddGradeTableLayoutPanel.Visible = true;
        }

        private void AddGradeFormSubmitButton_Click(object sender, EventArgs e)
        {
            this.AddGradeTableLayoutPanel.Visible = false;
            new DynamicMessageForm("").Show();
            
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
    }
}
