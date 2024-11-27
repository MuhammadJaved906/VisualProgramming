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
using DataAccess;

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
            //loadCustomer();

            // Create an object of clsSqlServer class to interact with the DataAccess layer
            clsSqlServer obj = new clsSqlServer();

            // Get the customer data from the DataAccess layer
            DataSet ds = clsSqlServer.getCustomerData();

            // Bind the data to the DataGridView
            dtgCustomer.DataSource = ds.Tables[0];
        }

        private void clearForm()
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Open a connection to the database using the connection string from the config file
            string strConnection = ConfigurationManager.ConnectionStrings["DBConn"].ToString();
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            // Create a DELETE SQL command
            string strCommand = "DELETE FROM CustomerTable WHERE CustomerName = @CustomerName";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

            // Execute the delete command
            objCommand.ExecuteNonQuery();

            // Close the connection
            objConnection.Close();

            // Clear the form fields after deletion
            clearForm();

            // Reload the DataGridView to reflect the updated list of customers
            loadCustomer();
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

        private void button2_Click(object sender, EventArgs e)
        {

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

