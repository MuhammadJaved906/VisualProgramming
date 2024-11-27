using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowForm_Lab8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void setValues(string name, string country, string gender, string hobby, string status)
        {
            label2.Text = name;
            label4.Text = country;
            label6.Text = gender;
            label8.Text = hobby;
            label10.Text = status;
        }
    }
}
