using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace CourseManagementApp
{
    public partial class StudentForm : Window
    {
        public StudentForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            List<Student> students = new List<Student>();
            string connectionString = "Server=DESKTOP-06NJIOH\\SQLEXPRESS;Database=CourseManagementApp;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["id"],
                        Name = reader["Name"].ToString(),
                        RegNo = reader["RegNo"].ToString()
                    });
                }
                StudentsDataGrid.ItemsSource = students;
            }
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string regNo = RegNoTextBox.Text;
            string connectionString = "Server=DESKTOP-06NJIOH\\SQLEXPRESS;Database=CourseManagementApp;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Student (Name, RegNo) VALUES (@Name, @RegNo)", conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@RegNo", regNo);
                cmd.ExecuteNonQuery();
            }
            LoadStudents(); // Refresh data grid
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
    }
}
