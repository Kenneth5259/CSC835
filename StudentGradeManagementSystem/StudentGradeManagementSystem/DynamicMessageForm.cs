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
    public partial class DynamicMessageForm : Form
    {
        public DynamicMessageForm()
        {
            InitializeComponent();
            this.DynamicMessageLabel.Text = "This is a placeholder for the dynmaic message/error form";
        }
        public DynamicMessageForm(string s)
        {
            InitializeComponent();
            this.DynamicMessageLabel.Text = s;
        }
    }
}
