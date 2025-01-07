using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QuizApp
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=quiz.db;Version=3;";

        public MainWindow()
        {
            InitializeComponent();
            LoadQuestions();
        }

        private async void LoadQuestions()
        {
            LoadingProgressBar.Visibility = Visibility.Visible;
            var questions = await Task.Run(() => GetQuestions());
            QuestionsDataGrid.ItemsSource = questions;
            LoadingProgressBar.Visibility = Visibility.Collapsed;
        }

        private List<Question> GetQuestions()
        {
            var questions = new List<Question>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Questions", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            Id = reader.GetInt32(0),
                            QuestionText = reader.GetString(1),
                            CorrectAnswer = reader.GetString(2),
                            AssignedMarks = reader.GetInt32(3),
                            TimeLimit = reader.GetInt32(4),
                            Topic = reader.GetString(5),
                            DifficultyLevel = reader.GetString(6)
                        });
                    }
                }
            }
            return questions;
        }

        private void AddQuestion(Question question)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Questions (QuestionText, CorrectAnswer, AssignedMarks, TimeLimit, Topic, DifficultyLevel)" +
                " VALUES (@QuestionText, @CorrectAnswer, @AssignedMarks, @TimeLimit, @Topic, @DifficultyLevel)", connection);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                command.Parameters.AddWithValue("@AssignedMarks", question.AssignedMarks);
                command.Parameters.AddWithValue("@TimeLimit", question.TimeLimit);
                command.Parameters.AddWithValue("@Topic", question.Topic);
                command.Parameters.AddWithValue("@DifficultyLevel", question.DifficultyLevel);
                command.ExecuteNonQuery();
            } // Add this closing bracket

            // Refresh the questions list
            LoadQuestions();
        }

        private async void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingProgressBar.Visibility = Visibility.Visible;
            await Task.Run(() => SaveChanges());
            LoadingProgressBar.Visibility = Visibility.Collapsed;
        }

        private void SaveChanges()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (var question in QuestionsDataGrid.ItemsSource)
                {
                    var command = new SQLiteCommand("UPDATE Questions SET QuestionText = @QuestionText, CorrectAnswer = @CorrectAnswer, AssignedMarks = @AssignedMarks, TimeLimit = @TimeLimit, Topic = @Topic, DifficultyLevel = @DifficultyLevel WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", question.Id);
                    command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                    command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                    command.Parameters.AddWithValue("@AssignedMarks", question.AssignedMarks);
                    command.Parameters.AddWithValue("@TimeLimit", question.TimeLimit);
                    command.Parameters.AddWithValue("@Topic", question.Topic);
                    command.Parameters.AddWithValue("@DifficultyLevel", question.DifficultyLevel);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void TopicComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TopicComboBox.SelectedItem != null)
            {
                var selectedTopic = TopicComboBox.SelectedItem.ToString();
                var filteredQuestions = GetQuestions().Where(q => q.Topic == selectedTopic).ToList();
                QuestionsDataGrid.ItemsSource = filteredQuestions;
            }
        }

        private void DifficultyComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (DifficultyComboBox.SelectedItem != null)
            {
                var selectedDifficulty = DifficultyComboBox.SelectedItem.ToString();
                var filteredQuestions = GetQuestions().Where(q => q.DifficultyLevel == selectedDifficulty).ToList();
                QuestionsDataGrid.ItemsSource = filteredQuestions;
            }
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public int AssignedMarks { get; set; }
        public int TimeLimit { get; set; }
        public string Topic { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
