using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace CourseManagementApp
{
    public partial class CourseForm : Window
    {
        public CourseForm()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            List<Course> courses = new List<Course>();
            string connectionString = "Server=DESKTOP-06NJIOH\\SQLEXPRESS;Database=CourseManagementApp;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Course", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        Id = (int)reader["id"],
                        Code = reader["Code"].ToString(),
                        Name = reader["Name"].ToString()
                    });
                }
                CoursesDataGrid.ItemsSource = courses;
            }
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            string code = CodeTextBox.Text;
            string name = NameTextBox.Text;
            string connectionString = "Server=DESKTOP-06NJIOH\\SQLEXPRESS;Database=CourseManagementApp;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Course (Code, Name) VALUES (@Code, @Name)", conn);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.ExecuteNonQuery();
            }
            LoadCourses(); // Refresh data grid
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
