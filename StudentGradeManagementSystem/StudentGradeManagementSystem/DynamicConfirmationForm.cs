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
    public partial class DynamicConfirmationForm : Form
    {
        public DynamicConfirmationForm()
        {
            InitializeComponent();
            this.label1.Text = "This is placeholder text";
        }
        public DynamicConfirmationForm(string s)
        {
            InitializeComponent();
            this.label1.Text = s;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmationButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
