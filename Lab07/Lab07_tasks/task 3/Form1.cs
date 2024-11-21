using System;
using System.Windows.Forms;

namespace lab07_task_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            // Clear previous results in ListBox
            listBoxResults.Items.Clear();

            // Calculate the square of numbers from 1 to 10
            for (int i = 1; i <= 10; i++)
            {
                int square = i * i;
                // Add the result to the ListBox
                listBoxResults.Items.Add($"Number: {i}, Square: {square}");
            }
        }

        private void listBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
