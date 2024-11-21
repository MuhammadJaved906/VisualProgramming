using System;
using System.Windows.Forms;

namespace lab07_task_02
{
    public partial class Form1 : Form
    {
        // Variables for calculation
        private double _result = 0;          // Stores the first operand
        private string _operation = "";      // Stores the current operator
        private bool _isOperationPerformed = false; // Tracks if an operation button was pressed

        public Form1()
        {
            InitializeComponent(); // Initializes the form
        }

        // Event handler for digit and decimal point buttons
        private void btn_Click(object sender, EventArgs e)
        {
            if (_isOperationPerformed)
            {
                txtDisplay.Text = ""; // Clear the display if an operation was previously performed
                _isOperationPerformed = false;
            }

            Button button = (Button)sender;

            if (txtDisplay.Text == "0")
                txtDisplay.Text = ""; // Remove leading zero for clean input

            txtDisplay.Text += button.Text; // Append the clicked button's text
        }

        // Event handler for operation buttons (+, -, *, /)
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (_isOperationPerformed)
            {
                _operation = button.Text;  // Update the operator if already performed
            }
            else
            {
                if (_result != 0)
                {
                    btnEquals.PerformClick();  // Perform the previous operation
                    _operation = button.Text;
                    _isOperationPerformed = true;
                }
                else
                {
                    _operation = button.Text;
                    _result = double.Parse(txtDisplay.Text); // Store the first operand
                    _isOperationPerformed = true;
                }
            }
        }

        // Event handler for Equals button (=)
        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_operation)
                {
                    case "+":
                        txtDisplay.Text = (_result + double.Parse(txtDisplay.Text)).ToString();
                        break;
                    case "-":
                        txtDisplay.Text = (_result - double.Parse(txtDisplay.Text)).ToString();
                        break;
                    case "*":
                        txtDisplay.Text = (_result * double.Parse(txtDisplay.Text)).ToString();
                        break;
                    case "/":
                        if (double.Parse(txtDisplay.Text) == 0)
                            throw new DivideByZeroException("Cannot divide by zero.");
                        txtDisplay.Text = (_result / double.Parse(txtDisplay.Text)).ToString();
                        break;
                    default:
                        break;
                }

                _result = double.Parse(txtDisplay.Text); // Update the result
                _operation = ""; // Reset the operation
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Handle division by zero or other errors
                txtDisplay.Text = "Error"; // Show an error message
            }
        }

        // Event handler for Clear button (C)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0"; // Reset the display
            _result = 0;
            _operation = "";
            _isOperationPerformed = false;
        }

        // Event handler for Decimal Point button (.)
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
                txtDisplay.Text += "."; // Append decimal point if not already present
        }
    }
}
