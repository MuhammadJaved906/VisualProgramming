using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab07_task_07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Display current date and time in the label
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");

            // Update date label every second
            dateLabel.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }
    }
}
