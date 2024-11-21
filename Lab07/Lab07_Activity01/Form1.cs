using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WelcomeForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGreeting_Click(object sender, EventArgs e)
        {
            string username = txtName.Text;
            if (!string.IsNullOrWhiteSpace(username))
            {
                lblGreeting.Text = $"Welcome ,{username}";
            }
            else
            {
                lblGreeting.Text = "Please Enter your name.";
            }
        }
    }
}
