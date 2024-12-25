using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace CourseManagementApp
{
    public partial class UnassignedCoursesForm : Window
    {
        public UnassignedCoursesForm()
        {
            InitializeComponent();
            LoadUnassignedCourses();
        }

        private void LoadUnassignedCourses()
        {
            List<Course> courses = new List<Course>();
            string connectionString = "Server=DESKTOP-06NJIOH\\SQLEXPRESS;Database=CourseManagementApp;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE id NOT IN (SELECT CourseID FROM StudentCourses)", conn);
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
                UnassignedCoursesDataGrid.ItemsSource = courses;
            }
        }
    }
}
