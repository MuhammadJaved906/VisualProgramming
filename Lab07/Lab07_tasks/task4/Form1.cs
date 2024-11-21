using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab07_task_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            // Try to parse the input Fahrenheit value
            if (double.TryParse(textBoxFahrenheit.Text, out double fahrenheit))
            {
                // Convert Fahrenheit to Celsius
                double celsius = (fahrenheit - 32) * 5 / 9;

                // Display the Celsius value in the TextBox (formatted to 2 decimal places)
                textBoxCelsius.Text = celsius.ToString("F2");
            }
            else
            {
                // Show an error message if the input is not valid
                MessageBox.Show("Please enter a valid number for Fahrenheit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Close the application
            this.Close();
        }
    }
}
