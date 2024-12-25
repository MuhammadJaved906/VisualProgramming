using System;
using System.Windows;

namespace CourseManagementApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for opening the Course Form
        private void OpenCourseForm_Click(object sender, RoutedEventArgs e)
        {
            CourseForm courseForm = new CourseForm();  // Create an instance of the CourseForm
            courseForm.Show();  // Show the Course Form
        }

        // Event handler for opening the Student Form
        private void OpenStudentForm_Click(object sender, RoutedEventArgs e)
        {
            StudentForm studentForm = new StudentForm();  // Create an instance of the StudentForm
            studentForm.Show();  // Show the Student Form
        }

        // Event handler for opening the Unassigned Courses Form
        private void OpenUnassignedCoursesForm_Click(object sender, RoutedEventArgs e)
        {
            UnassignedCoursesForm unassignedCoursesForm = new UnassignedCoursesForm();  // Create an instance of the UnassignedCoursesForm
            unassignedCoursesForm.Show();  // Show the Unassigned Courses Form
        }
    }
}
