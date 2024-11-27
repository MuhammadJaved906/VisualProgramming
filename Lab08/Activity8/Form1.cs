using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;

namespace WindowForm_Lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadCustomer();
        }

        private void clearForm()
        {

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        private void displayCustomer(string strCustomer)
        {
            // Connection string from the config file
            string strConnection = ConfigurationManager.ConnectionStrings["DBConn"].ToString();
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            // SQL command to fetch the customer data based on the customer name
            string strCommand = "SELECT * FROM CustomerTable WHERE CustomerName = @CustomerName";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.Parameters.AddWithValue("@CustomerName", strCustomer);

            // Create a DataSet and fill it with the query results
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);

            // Check if data is found
            if (objDataSet.Tables[0].Rows.Count > 0)
            {

                string Gender = objDataSet.Tables[0].Rows[0]["Gender"].ToString();
                if (Gender.Equals("Male")) radioButton1.Checked = true;
                else radioButton2.Checked = true;

                string Hobby = objDataSet.Tables[0].Rows[0]["Hobby"].ToString();
                if (Hobby.Equals("Reading")) checkBox1.Checked = true;
                else checkBox2.Checked = true;

                string Married = objDataSet.Tables[0].Rows[0]["IsMarried"].ToString();
                if (Married.Equals("True")) radioButton3.Checked = true;
                else radioButton4.Checked = true;
            }

            objConnection.Close();
        }


        private void dtgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the form before loading new data
            clearForm();

            // Check that the clicked row is valid
            if (e.RowIndex >= 0)
            {
                // Get the customer name from the clicked row (assuming the first column contains the customer name)
                string customerName = dtgCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Display the customer details based on the clicked customer name
                displayCustomer(customerName);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the values from the form
            string gender = radioButton1.Checked ? "Male" : "Female";
            string hobby = checkBox1.Checked ? "Reading" : "Painting";
            string status = radioButton3.Checked ? "True" : "False";


            // Update the data in the database
            string strConnection = ConfigurationManager.ConnectionStrings["DBConn"].ToString();
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            string strCommand = "UPDATE CustomerTable SET Country = @Country, Gender = @Gender, Hobby = @Hobby, IsMarried = @IsMarried WHERE CustomerName = @CustomerName";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

            // Add parameters to avoid SQL injection
            objCommand.Parameters.AddWithValue("@Gender", gender);
            objCommand.Parameters.AddWithValue("@Hobby", hobby);
            objCommand.Parameters.AddWithValue("@IsMarried", status);

            objCommand.ExecuteNonQuery(); // Execute the update command
            objConnection.Close();

            // Reload the data grid to show the updated information
            loadCustomer();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            // Confirm the deletion action
            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Connection string
                string strConnection = ConfigurationManager.ConnectionStrings["DBConn"].ToString();
                SqlConnection objConnection = new SqlConnection(strConnection);
                objConnection.Open();

                // SQL command to delete the customer based on the customer name
                string strCommand = "DELETE FROM CustomerTable WHERE CustomerName = @CustomerName";
                SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

                objCommand.ExecuteNonQuery(); // Execute the delete command
                objConnection.Close();

                // Clear the form and reload the data grid
                clearForm();
                loadCustomer();
            }
        }
        private void loadCustomer()
        {
            // Retrieve connection string from the configuration file
            string connectionString = ConfigurationManager.ConnectionStrings["DBConn"].ToString();

            try
            {
                // Create and open the SQL connection using the connection string from app.config
                using (SqlConnection objConnection = new SqlConnection(connectionString))
                {
                    objConnection.Open();

                    // SQL query to fetch customer data
                    string strCommand = "SELECT * FROM CustomerTable";

                    // Create SqlCommand and execute it
                    SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

                    // Create DataSet to hold the data
                    DataSet objDataSet = new DataSet();
                    SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                    objAdapter.Fill(objDataSet);

                    // Bind the DataGridView to the data
                    dtgCustomer.DataSource = objDataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //string gender, hobby, status = "";
            //if (radioButton1.Checked)
            //{
            //    gender = "Male";
            //}
            //else
            //{
            //    gender = "Female";
            //}
            //if (checkBox1.Checked)
            //{
            //    hobby = "Reading";
            //}
            //else
            //{
            //    hobby = "Writing";
            //}
            //if (radioButton3.Checked)
            //{
            //    status = "Married";
            //}
            //else
            //{
            //    status = "Unmarried";
            //}
            //Form2 objPreview = new Form2();
            //objPreview.setValues(textBox1.Text, textBox2.Text, gender, hobby, status);
            //objPreview.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //loadCustomer();
        }
        private void frmCustomerDataEntry_Load(object sender, EventArgs e)
        {
            //loadCustomer();
        }
        //private void loadCustomer()
        //{
        //    // Open a Connection
        //    string strConnection = "Data Source=.\\sqlexpress;Initial Catalog=CustomerDB;Integrated Security=True";
        //    SqlConnection objConnection = new SqlConnection(strConnection);
        //    objConnection.Open();
        //    // Fire a Command
        //    string strCommand = "Select * From CustomerTable";
        //    SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
        //    // Bind Data with UI
        //    DataSet objDataSet = new DataSet();
        //    SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
        //    objAdapter.Fill(objDataSet);
        //    dtgCustomer.DataSource = objDataSet.Tables[0];
        //    // Close the Connection
        //    objConnection.Close();
        //}
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    string Gender, Hobby, Status = "";
        //    if (radioButton1.Checked) Gender = "Male";
        //    else Gender = "Female";
        //    if (checkBox1.Checked) Hobby = "Reading";
        //    else Hobby = "Painting";
        //    if (radioButton3.Checked) Status = "1";
        //    else Status = "0";

        //    //Open a Connection
        //    string strConnection = "Data Source=.\\sqlexpress;Initial Catalog=CustomerDB;"
        //    + "Integrated Security=True";
        //    SqlConnection objConnection = new SqlConnection(strConnection);
        //    objConnection.Open();
        //    // Fire a Command
        //    string strCommand = "insert into CustomerTable values('"  + "','"
        //    + Gender + "', '"
        //    + Hobby + "', "
        //    + Status + " )";
        //    SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
        //    objCommand.ExecuteNonQuery();
        //    // Close the Connection
        //    objConnection.Close();
        //    loadCustomer();

        //}
    }
}

