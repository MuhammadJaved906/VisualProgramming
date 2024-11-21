using System;
using System.Windows.Forms;

namespace lab07_task_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Function to calculate the factorial
        private long CalculateFactorial(int number)
        {
            long factorial = 1;
            if (number < 0)
            {
                MessageBox.Show("Factorial is not defined for negative numbers.");
                return -1;  // Return an error value for negative input
            }
            // Loop to calculate factorial
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        // Button click event to calculate the factorial
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            // Parse the input number from the TextBox
            if (int.TryParse(textBoxInput.Text, out int number))
            {
                // Call the CalculateFactorial function
                long result = CalculateFactorial(number);

                // Display the result in the second label
                if (result != -1)
                {
                    textBoxResult.Text = result.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        // Button click event for Exit (Close the form)
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
