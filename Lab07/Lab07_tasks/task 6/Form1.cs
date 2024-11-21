using System;
using System.Windows.Forms;

namespace lab07_task_06
{
    public partial class Form1 : Form
    {
        private int timeLeft;  // Store the time left in the countdown

        public Form1()
        {
            InitializeComponent();
        }

        // Button click event to start the countdown
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Check if the user entered a valid number for the countdown time
            if (int.TryParse(textBoxSetTime.Text, out timeLeft) && timeLeft > 0)
            {
                // Display the time left in the "Time Left" textbox
                textBoxTimeLeft.Text = timeLeft.ToString();

                // Start the countdown timer
                timerCountdown.Start();
            }
            else
            {
                // Show a message box if the input is not valid
                MessageBox.Show("Please enter a valid positive number for the time.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Timer tick event to update the time left
        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Decrease the time left by 1 second
                timeLeft--;

                // Update the "Time Left" textbox with the new time
                textBoxTimeLeft.Text = timeLeft.ToString();
            }
            else
            {
                // Stop the timer when the countdown reaches 0
                timerCountdown.Stop();

                // Show a message box when time is over
                MessageBox.Show("Time Over!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
