using System;
using System.Windows.Forms;

namespace lab07_task_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for Add button click
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNum1.Text) || string.IsNullOrEmpty(textBoxNum2.Text))
            {
                MessageBox.Show("Please enter both numbers.");
                return;
            }

            double num1 = Convert.ToDouble(textBoxNum1.Text);
            double num2 = Convert.ToDouble(textBoxNum2.Text);
            double result = num1 + num2;
            textBoxResult.Text = result.ToString();
        }

        // Event handler for Subtract button click
        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNum1.Text) || string.IsNullOrEmpty(textBoxNum2.Text))
            {
                MessageBox.Show("Please enter both numbers.");
                return;
            }

            double num1 = Convert.ToDouble(textBoxNum1.Text);
            double num2 = Convert.ToDouble(textBoxNum2.Text);
            double result = num1 - num2;
            textBoxResult.Text = result.ToString();
        }

        // Event handler for Multiply button click
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNum1.Text) || string.IsNullOrEmpty(textBoxNum2.Text))
            {
                MessageBox.Show("Please enter both numbers.");
                return;
            }

            double num1 = Convert.ToDouble(textBoxNum1.Text);
            double num2 = Convert.ToDouble(textBoxNum2.Text);
            double result = num1 * num2;
            textBoxResult.Text = result.ToString();
        }

        // Event handler for Divide button click
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNum1.Text) || string.IsNullOrEmpty(textBoxNum2.Text))
            {
                MessageBox.Show("Please enter both numbers.");
                return;
            }

            double num1 = Convert.ToDouble(textBoxNum1.Text);
            double num2 = Convert.ToDouble(textBoxNum2.Text);

            // Check for division by zero
            if (num2 == 0)
            {
                MessageBox.Show("Cannot divide by zero.");
            }
            else
            {
                double result = num1 / num2;
                textBoxResult.Text = result.ToString();
            }
        }
    }
}
